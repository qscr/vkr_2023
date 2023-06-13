part of 'items_page_bloc.dart';

@freezed
class ItemsPageEvent with _$ItemsPageEvent {
  const factory ItemsPageEvent.getItems() = GetItems;
  const factory ItemsPageEvent.deleteItems() = DeleteItems;
}
