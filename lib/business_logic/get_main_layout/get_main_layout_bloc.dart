import 'dart:convert';

import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/models/api/dynamic_content_response.dart';
import 'package:flutter_dynamic_store/service/api/layout_api_client.dart';
import 'package:flutter_dynamic_store/test_json_string.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'get_main_layout_state.dart';
part 'get_main_layout_event.dart';
part 'get_main_layout_bloc.freezed.dart';

class GetMainLayoutBloc extends Bloc<GetMainLayoutEvent, GetMainLayoutState> {
  final LayoutApiClient _apiClient;

  GetMainLayoutBloc(this._apiClient) : super(const GetMainLayoutState.initial()) {
    on<GetMainLayout>(
      (event, emit) async {
        await _getMainLayout(emit);
      },
    );
  }

  Future<void> _getMainLayout(Emitter<GetMainLayoutState> emit) async {
    emit(const Loading());
    try {
      final response = await _apiClient.getMainLayout();
      final layoutDesign = jsonDecode(response["layoutDesign"]);
      // final dynamicContent = DynamicContentResponse.fromJson(layoutDesign["information"]);
      final dynamicContent = DynamicContentResponse.fromJson(jsonDecode(testJsonRouteString));
      emit(Success(dynamicContent));
    } catch (e) {
      emit(const Error());
    }
  }
}
