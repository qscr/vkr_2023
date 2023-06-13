import 'package:dio/dio.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/helpers/dio_extensions.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'initial_state.dart';
part 'initial_event.dart';
part 'initial_bloc.freezed.dart';

class InitialBloc extends Bloc<InitialEvent, InitialState> {
  final Dio _dio;

  InitialBloc(this._dio) : super(const InitialState.initial()) {
    on<ResolveNextRoute>(
      (event, emit) async {
        await _resolveNextRoute(emit);
      },
    );
  }

  Future<void> _resolveNextRoute(Emitter<InitialState> emit) async {
    final accessToken = await const FlutterSecureStorage().read(key: "access_token");
    if (accessToken != null) {
      _dio.setAuthorizationToken(accessToken);
    }

    await Future.delayed(const Duration(seconds: 1));

    if (kIsWeb) {
      await _processWebApp(
        emit: emit,
        haveToken: accessToken != null,
      );
    } else {
      await _processMobileApp(
        emit: emit,
        haveToken: accessToken != null,
      );
    }
  }

  Future<void> _processWebApp({
    required Emitter<InitialState> emit,
    required bool haveToken,
  }) async {
    if (!haveToken) {
      emit(const GoToWebGeneratorLogin());
    } else {
      emit(const GoToWebGeneratorApp());
    }
  }

  Future<void> _processMobileApp({
    required Emitter<InitialState> emit,
    required bool haveToken,
  }) async {
    if (!haveToken) {
      emit(const GoToLogin());
    } else {
      emit(const GoToApp());
    }
  }
}
