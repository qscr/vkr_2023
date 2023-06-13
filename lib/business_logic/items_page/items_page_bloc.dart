import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/models/api/product/get/get_shop_products_entities_response.dart';
import 'package:flutter_dynamic_store/models/base_error_state.dart';
import 'package:flutter_dynamic_store/service/api/product_api_client.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'items_page_state.dart';
part 'items_page_event.dart';
part 'items_page_bloc.freezed.dart';

class ItemsPageBloc extends Bloc<ItemsPageEvent, ItemsPageState> {
  final ProductApiClient _apiClient;

  ItemsPageBloc(this._apiClient) : super(const ItemsPageState.initial()) {
    on<GetItems>(
      (event, emit) async {
        await _getItems(emit: emit);
      },
    );
  }

  Future<void> _getItems({required Emitter<ItemsPageState> emit}) async {
    emit(const ItemsLoading());
    try {
      final response = await _apiClient.getProducts();
      emit(ItemsSuccess(response.entities ?? []));
    } catch (e) {
      emit(const ItemsError("Не удалось получить товары магазина"));
    }
  }
}
