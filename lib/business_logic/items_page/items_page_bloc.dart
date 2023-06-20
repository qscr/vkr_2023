import 'dart:io';

import 'package:collection/collection.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/models/api/product/delete/delete_product_request.dart';
import 'package:flutter_dynamic_store/models/api/product/get/get_shop_products_entities_response.dart';
import 'package:flutter_dynamic_store/models/api/product/post/post_product_request.dart';
import 'package:flutter_dynamic_store/models/base_error_state.dart';
import 'package:flutter_dynamic_store/service/api/file_api_client.dart';
import 'package:flutter_dynamic_store/service/api/product_api_client.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:image_picker/image_picker.dart';

part 'items_page_state.dart';
part 'items_page_event.dart';
part 'items_page_bloc.freezed.dart';

class ItemsPageBloc extends Bloc<ItemsPageEvent, ItemsPageState> {
  final ProductApiClient _apiClient;
  final FileApiClient _fileApiClient;

  ItemsPageBloc(this._apiClient, this._fileApiClient) : super(const ItemsPageState.initial()) {
    on<GetItems>(
      (event, emit) async {
        await _getItems(emit: emit);
      },
    );

    on<DeleteItems>(
      (event, emit) async {
        await _deleteItems(
          emit: emit,
          items: event.items,
        );
      },
    );

    on<CreateItem>(
      (event, emit) async {
        await _createItem(
          emit: emit,
          pictures: event.pictures,
          description: event.description,
          name: event.name,
          cost: event.cost,
        );
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

  Future<void> _deleteItems({
    required Emitter<ItemsPageState> emit,
    required List<GetShopProductsEntitiesResponse> items,
  }) async {
    final lastItems = state as ItemsSuccess;
    try {
      await _apiClient.deleteProduct(
        DeleteProductRequest(
          productIds: items.map((e) => e.id).whereNotNull().toList(),
        ),
      );
      emit(const ItemsLoading());
      emit(
        ItemsSuccess(
          lastItems.items.where((element) => !items.contains(element)).toList(),
        ),
      );
    } catch (e) {
      emit(const ItemsError("Не удалось удалить выбранные товары"));
    }
  }

  Future<void> _createItem({
    required Emitter<ItemsPageState> emit,
    required List<XFile> pictures,
    required String description,
    required String name,
    required double cost,
  }) async {
    final lastItems = state as ItemsSuccess;
    try {
      final List<String> pictureIds = [];
      for (var file in pictures) {
        try {
          final response = await _fileApiClient.uploadFile(File(file.path));
          if (response.fileNameToFileId?.fileId != null) {
            pictureIds.add(response.fileNameToFileId!.fileId!);
          }
        } catch (e) {}
      }
      final response = await _apiClient.createProduct(
        PostProductRequest(
          name: name,
          description: description,
          price: cost,
          photoIds: pictureIds,
        ),
      );
      emit(const ItemsLoading());
      emit(
        ItemsSuccess(
          [
            ...lastItems.items,
            GetShopProductsEntitiesResponse(
              id: response.id,
              name: name,
              description: description,
              price: cost,
              photoIds: pictureIds,
            ),
          ],
        ),
      );
    } catch (e) {
      emit(const ItemsError("Не удалось создать новый товар"));
    }
  }
}
