import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/service/api/layout_api_client.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'web_generator_state.dart';
part 'web_generator_event.dart';
part 'web_generator_bloc.freezed.dart';

class WebGeneratorBloc extends Bloc<WebGeneratorEvent, WebGeneratorState> {
  final LayoutApiClient _apiClient;

  WebGeneratorBloc(this._apiClient) : super(const WebGeneratorState.initial()) {
    on<UploadNewLayout>(
      (event, emit) async {
        emit(const Loading());
        try {
          await _apiClient.updateLayout(event.layout);
          emit(const UploadingSuccess());
        } catch (e) {
          emit(const UploadingError());
        }
      },
    );
  }
}
