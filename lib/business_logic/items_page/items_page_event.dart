part of 'items_page_bloc.dart';

@freezed
class ItemsPageEvent with _$ItemsPageEvent {
  const factory ItemsPageEvent.getItems() = GetItems;
  const factory ItemsPageEvent.deleteItems(List<GetShopProductsEntitiesResponse> items) =
      DeleteItems;
  const factory ItemsPageEvent.createItem({
    required List<XFile> pictures,
    required String description,
    required String name,
    required double cost,
  }) = CreateItem;
}
