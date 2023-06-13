part of 'get_main_layout_bloc.dart';

@freezed
class GetMainLayoutState with _$GetMainLayoutState {
  const factory GetMainLayoutState.initial() = Initial;
  const factory GetMainLayoutState.loadInProgress() = Loading;
  const factory GetMainLayoutState.success(DynamicContentResponse layout) = Success;
  const factory GetMainLayoutState.error() = Error;
}
