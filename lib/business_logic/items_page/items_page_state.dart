part of 'items_page_bloc.dart';

@freezed
class ItemsPageState with _$ItemsPageState {
  const factory ItemsPageState.initial() = Initial;
  const factory ItemsPageState.itemsLoading() = ItemsLoading;
  const factory ItemsPageState.itemsSuccess(List<GetShopProductsEntitiesResponse> items) =
      ItemsSuccess;
  @Implements<BaseErrorState>()
  const factory ItemsPageState.itemsError(String message) = ItemsError;
}
