import 'package:dio/dio.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/helpers/dio_extensions.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'logout_state.dart';
part 'logout_event.dart';
part 'logout_bloc.freezed.dart';

class LogoutBloc extends Bloc<LogoutEvent, LogoutState> {
  final Dio _dio;

  LogoutBloc(this._dio) : super(const LogoutState.logoutInitial()) {
    on<Logout>(
      (event, emit) async {
        await const FlutterSecureStorage().deleteAll();
        _dio.deleteAuthorizationToken();
        emit(const LogoutSuccess());
      },
    );
  }
}
