// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'items_page_bloc.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
mixin _$ItemsPageState {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() itemsLoading,
    required TResult Function(List<GetShopProductsEntitiesResponse> items)
        itemsSuccess,
    required TResult Function(String message) itemsError,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? initial,
    TResult? Function()? itemsLoading,
    TResult? Function(List<GetShopProductsEntitiesResponse> items)?
        itemsSuccess,
    TResult? Function(String message)? itemsError,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? itemsLoading,
    TResult Function(List<GetShopProductsEntitiesResponse> items)? itemsSuccess,
    TResult Function(String message)? itemsError,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(Initial value) initial,
    required TResult Function(ItemsLoading value) itemsLoading,
    required TResult Function(ItemsSuccess value) itemsSuccess,
    required TResult Function(ItemsError value) itemsError,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(Initial value)? initial,
    TResult? Function(ItemsLoading value)? itemsLoading,
    TResult? Function(ItemsSuccess value)? itemsSuccess,
    TResult? Function(ItemsError value)? itemsError,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(Initial value)? initial,
    TResult Function(ItemsLoading value)? itemsLoading,
    TResult Function(ItemsSuccess value)? itemsSuccess,
    TResult Function(ItemsError value)? itemsError,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ItemsPageStateCopyWith<$Res> {
  factory $ItemsPageStateCopyWith(
          ItemsPageState value, $Res Function(ItemsPageState) then) =
      _$ItemsPageStateCopyWithImpl<$Res, ItemsPageState>;
}

/// @nodoc
class _$ItemsPageStateCopyWithImpl<$Res, $Val extends ItemsPageState>
    implements $ItemsPageStateCopyWith<$Res> {
  _$ItemsPageStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;
}

/// @nodoc
abstract class _$$InitialCopyWith<$Res> {
  factory _$$InitialCopyWith(_$Initial value, $Res Function(_$Initial) then) =
      __$$InitialCopyWithImpl<$Res>;
}

/// @nodoc
class __$$InitialCopyWithImpl<$Res>
    extends _$ItemsPageStateCopyWithImpl<$Res, _$Initial>
    implements _$$InitialCopyWith<$Res> {
  __$$InitialCopyWithImpl(_$Initial _value, $Res Function(_$Initial) _then)
      : super(_value, _then);
}

/// @nodoc

class _$Initial implements Initial {
  const _$Initial();

  @override
  String toString() {
    return 'ItemsPageState.initial()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is _$Initial);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() itemsLoading,
    required TResult Function(List<GetShopProductsEntitiesResponse> items)
        itemsSuccess,
    required TResult Function(String message) itemsError,
  }) {
    return initial();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? initial,
    TResult? Function()? itemsLoading,
    TResult? Function(List<GetShopProductsEntitiesResponse> items)?
        itemsSuccess,
    TResult? Function(String message)? itemsError,
  }) {
    return initial?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? itemsLoading,
    TResult Function(List<GetShopProductsEntitiesResponse> items)? itemsSuccess,
    TResult Function(String message)? itemsError,
    required TResult orElse(),
  }) {
    if (initial != null) {
      return initial();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(Initial value) initial,
    required TResult Function(ItemsLoading value) itemsLoading,
    required TResult Function(ItemsSuccess value) itemsSuccess,
    required TResult Function(ItemsError value) itemsError,
  }) {
    return initial(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(Initial value)? initial,
    TResult? Function(ItemsLoading value)? itemsLoading,
    TResult? Function(ItemsSuccess value)? itemsSuccess,
    TResult? Function(ItemsError value)? itemsError,
  }) {
    return initial?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(Initial value)? initial,
    TResult Function(ItemsLoading value)? itemsLoading,
    TResult Function(ItemsSuccess value)? itemsSuccess,
    TResult Function(ItemsError value)? itemsError,
    required TResult orElse(),
  }) {
    if (initial != null) {
      return initial(this);
    }
    return orElse();
  }
}

abstract class Initial implements ItemsPageState {
  const factory Initial() = _$Initial;
}

/// @nodoc
abstract class _$$ItemsLoadingCopyWith<$Res> {
  factory _$$ItemsLoadingCopyWith(
          _$ItemsLoading value, $Res Function(_$ItemsLoading) then) =
      __$$ItemsLoadingCopyWithImpl<$Res>;
}

/// @nodoc
class __$$ItemsLoadingCopyWithImpl<$Res>
    extends _$ItemsPageStateCopyWithImpl<$Res, _$ItemsLoading>
    implements _$$ItemsLoadingCopyWith<$Res> {
  __$$ItemsLoadingCopyWithImpl(
      _$ItemsLoading _value, $Res Function(_$ItemsLoading) _then)
      : super(_value, _then);
}

/// @nodoc

class _$ItemsLoading implements ItemsLoading {
  const _$ItemsLoading();

  @override
  String toString() {
    return 'ItemsPageState.itemsLoading()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is _$ItemsLoading);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() itemsLoading,
    required TResult Function(List<GetShopProductsEntitiesResponse> items)
        itemsSuccess,
    required TResult Function(String message) itemsError,
  }) {
    return itemsLoading();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? initial,
    TResult? Function()? itemsLoading,
    TResult? Function(List<GetShopProductsEntitiesResponse> items)?
        itemsSuccess,
    TResult? Function(String message)? itemsError,
  }) {
    return itemsLoading?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? itemsLoading,
    TResult Function(List<GetShopProductsEntitiesResponse> items)? itemsSuccess,
    TResult Function(String message)? itemsError,
    required TResult orElse(),
  }) {
    if (itemsLoading != null) {
      return itemsLoading();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(Initial value) initial,
    required TResult Function(ItemsLoading value) itemsLoading,
    required TResult Function(ItemsSuccess value) itemsSuccess,
    required TResult Function(ItemsError value) itemsError,
  }) {
    return itemsLoading(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(Initial value)? initial,
    TResult? Function(ItemsLoading value)? itemsLoading,
    TResult? Function(ItemsSuccess value)? itemsSuccess,
    TResult? Function(ItemsError value)? itemsError,
  }) {
    return itemsLoading?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(Initial value)? initial,
    TResult Function(ItemsLoading value)? itemsLoading,
    TResult Function(ItemsSuccess value)? itemsSuccess,
    TResult Function(ItemsError value)? itemsError,
    required TResult orElse(),
  }) {
    if (itemsLoading != null) {
      return itemsLoading(this);
    }
    return orElse();
  }
}

abstract class ItemsLoading implements ItemsPageState {
  const factory ItemsLoading() = _$ItemsLoading;
}

/// @nodoc
abstract class _$$ItemsSuccessCopyWith<$Res> {
  factory _$$ItemsSuccessCopyWith(
          _$ItemsSuccess value, $Res Function(_$ItemsSuccess) then) =
      __$$ItemsSuccessCopyWithImpl<$Res>;
  @useResult
  $Res call({List<GetShopProductsEntitiesResponse> items});
}

/// @nodoc
class __$$ItemsSuccessCopyWithImpl<$Res>
    extends _$ItemsPageStateCopyWithImpl<$Res, _$ItemsSuccess>
    implements _$$ItemsSuccessCopyWith<$Res> {
  __$$ItemsSuccessCopyWithImpl(
      _$ItemsSuccess _value, $Res Function(_$ItemsSuccess) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? items = null,
  }) {
    return _then(_$ItemsSuccess(
      null == items
          ? _value._items
          : items // ignore: cast_nullable_to_non_nullable
              as List<GetShopProductsEntitiesResponse>,
    ));
  }
}

/// @nodoc

class _$ItemsSuccess implements ItemsSuccess {
  const _$ItemsSuccess(final List<GetShopProductsEntitiesResponse> items)
      : _items = items;

  final List<GetShopProductsEntitiesResponse> _items;
  @override
  List<GetShopProductsEntitiesResponse> get items {
    if (_items is EqualUnmodifiableListView) return _items;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_items);
  }

  @override
  String toString() {
    return 'ItemsPageState.itemsSuccess(items: $items)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$ItemsSuccess &&
            const DeepCollectionEquality().equals(other._items, _items));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(_items));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$ItemsSuccessCopyWith<_$ItemsSuccess> get copyWith =>
      __$$ItemsSuccessCopyWithImpl<_$ItemsSuccess>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() itemsLoading,
    required TResult Function(List<GetShopProductsEntitiesResponse> items)
        itemsSuccess,
    required TResult Function(String message) itemsError,
  }) {
    return itemsSuccess(items);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? initial,
    TResult? Function()? itemsLoading,
    TResult? Function(List<GetShopProductsEntitiesResponse> items)?
        itemsSuccess,
    TResult? Function(String message)? itemsError,
  }) {
    return itemsSuccess?.call(items);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? itemsLoading,
    TResult Function(List<GetShopProductsEntitiesResponse> items)? itemsSuccess,
    TResult Function(String message)? itemsError,
    required TResult orElse(),
  }) {
    if (itemsSuccess != null) {
      return itemsSuccess(items);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(Initial value) initial,
    required TResult Function(ItemsLoading value) itemsLoading,
    required TResult Function(ItemsSuccess value) itemsSuccess,
    required TResult Function(ItemsError value) itemsError,
  }) {
    return itemsSuccess(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(Initial value)? initial,
    TResult? Function(ItemsLoading value)? itemsLoading,
    TResult? Function(ItemsSuccess value)? itemsSuccess,
    TResult? Function(ItemsError value)? itemsError,
  }) {
    return itemsSuccess?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(Initial value)? initial,
    TResult Function(ItemsLoading value)? itemsLoading,
    TResult Function(ItemsSuccess value)? itemsSuccess,
    TResult Function(ItemsError value)? itemsError,
    required TResult orElse(),
  }) {
    if (itemsSuccess != null) {
      return itemsSuccess(this);
    }
    return orElse();
  }
}

abstract class ItemsSuccess implements ItemsPageState {
  const factory ItemsSuccess(
      final List<GetShopProductsEntitiesResponse> items) = _$ItemsSuccess;

  List<GetShopProductsEntitiesResponse> get items;
  @JsonKey(ignore: true)
  _$$ItemsSuccessCopyWith<_$ItemsSuccess> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class _$$ItemsErrorCopyWith<$Res> {
  factory _$$ItemsErrorCopyWith(
          _$ItemsError value, $Res Function(_$ItemsError) then) =
      __$$ItemsErrorCopyWithImpl<$Res>;
  @useResult
  $Res call({String message});
}

/// @nodoc
class __$$ItemsErrorCopyWithImpl<$Res>
    extends _$ItemsPageStateCopyWithImpl<$Res, _$ItemsError>
    implements _$$ItemsErrorCopyWith<$Res> {
  __$$ItemsErrorCopyWithImpl(
      _$ItemsError _value, $Res Function(_$ItemsError) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? message = null,
  }) {
    return _then(_$ItemsError(
      null == message
          ? _value.message
          : message // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc

class _$ItemsError implements ItemsError {
  const _$ItemsError(this.message);

  @override
  final String message;

  @override
  String toString() {
    return 'ItemsPageState.itemsError(message: $message)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$ItemsError &&
            (identical(other.message, message) || other.message == message));
  }

  @override
  int get hashCode => Object.hash(runtimeType, message);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$ItemsErrorCopyWith<_$ItemsError> get copyWith =>
      __$$ItemsErrorCopyWithImpl<_$ItemsError>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() itemsLoading,
    required TResult Function(List<GetShopProductsEntitiesResponse> items)
        itemsSuccess,
    required TResult Function(String message) itemsError,
  }) {
    return itemsError(message);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? initial,
    TResult? Function()? itemsLoading,
    TResult? Function(List<GetShopProductsEntitiesResponse> items)?
        itemsSuccess,
    TResult? Function(String message)? itemsError,
  }) {
    return itemsError?.call(message);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? itemsLoading,
    TResult Function(List<GetShopProductsEntitiesResponse> items)? itemsSuccess,
    TResult Function(String message)? itemsError,
    required TResult orElse(),
  }) {
    if (itemsError != null) {
      return itemsError(message);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(Initial value) initial,
    required TResult Function(ItemsLoading value) itemsLoading,
    required TResult Function(ItemsSuccess value) itemsSuccess,
    required TResult Function(ItemsError value) itemsError,
  }) {
    return itemsError(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(Initial value)? initial,
    TResult? Function(ItemsLoading value)? itemsLoading,
    TResult? Function(ItemsSuccess value)? itemsSuccess,
    TResult? Function(ItemsError value)? itemsError,
  }) {
    return itemsError?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(Initial value)? initial,
    TResult Function(ItemsLoading value)? itemsLoading,
    TResult Function(ItemsSuccess value)? itemsSuccess,
    TResult Function(ItemsError value)? itemsError,
    required TResult orElse(),
  }) {
    if (itemsError != null) {
      return itemsError(this);
    }
    return orElse();
  }
}

abstract class ItemsError implements ItemsPageState, BaseErrorState {
  const factory ItemsError(final String message) = _$ItemsError;

  String get message;
  @JsonKey(ignore: true)
  _$$ItemsErrorCopyWith<_$ItemsError> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
mixin _$ItemsPageEvent {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() getItems,
    required TResult Function(List<GetShopProductsEntitiesResponse> items)
        deleteItems,
    required TResult Function(
            List<XFile> pictures, String description, String name, double cost)
        createItem,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? getItems,
    TResult? Function(List<GetShopProductsEntitiesResponse> items)? deleteItems,
    TResult? Function(
            List<XFile> pictures, String description, String name, double cost)?
        createItem,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? getItems,
    TResult Function(List<GetShopProductsEntitiesResponse> items)? deleteItems,
    TResult Function(
            List<XFile> pictures, String description, String name, double cost)?
        createItem,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(GetItems value) getItems,
    required TResult Function(DeleteItems value) deleteItems,
    required TResult Function(CreateItem value) createItem,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(GetItems value)? getItems,
    TResult? Function(DeleteItems value)? deleteItems,
    TResult? Function(CreateItem value)? createItem,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(GetItems value)? getItems,
    TResult Function(DeleteItems value)? deleteItems,
    TResult Function(CreateItem value)? createItem,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ItemsPageEventCopyWith<$Res> {
  factory $ItemsPageEventCopyWith(
          ItemsPageEvent value, $Res Function(ItemsPageEvent) then) =
      _$ItemsPageEventCopyWithImpl<$Res, ItemsPageEvent>;
}

/// @nodoc
class _$ItemsPageEventCopyWithImpl<$Res, $Val extends ItemsPageEvent>
    implements $ItemsPageEventCopyWith<$Res> {
  _$ItemsPageEventCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;
}

/// @nodoc
abstract class _$$GetItemsCopyWith<$Res> {
  factory _$$GetItemsCopyWith(
          _$GetItems value, $Res Function(_$GetItems) then) =
      __$$GetItemsCopyWithImpl<$Res>;
}

/// @nodoc
class __$$GetItemsCopyWithImpl<$Res>
    extends _$ItemsPageEventCopyWithImpl<$Res, _$GetItems>
    implements _$$GetItemsCopyWith<$Res> {
  __$$GetItemsCopyWithImpl(_$GetItems _value, $Res Function(_$GetItems) _then)
      : super(_value, _then);
}

/// @nodoc

class _$GetItems implements GetItems {
  const _$GetItems();

  @override
  String toString() {
    return 'ItemsPageEvent.getItems()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is _$GetItems);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() getItems,
    required TResult Function(List<GetShopProductsEntitiesResponse> items)
        deleteItems,
    required TResult Function(
            List<XFile> pictures, String description, String name, double cost)
        createItem,
  }) {
    return getItems();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? getItems,
    TResult? Function(List<GetShopProductsEntitiesResponse> items)? deleteItems,
    TResult? Function(
            List<XFile> pictures, String description, String name, double cost)?
        createItem,
  }) {
    return getItems?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? getItems,
    TResult Function(List<GetShopProductsEntitiesResponse> items)? deleteItems,
    TResult Function(
            List<XFile> pictures, String description, String name, double cost)?
        createItem,
    required TResult orElse(),
  }) {
    if (getItems != null) {
      return getItems();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(GetItems value) getItems,
    required TResult Function(DeleteItems value) deleteItems,
    required TResult Function(CreateItem value) createItem,
  }) {
    return getItems(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(GetItems value)? getItems,
    TResult? Function(DeleteItems value)? deleteItems,
    TResult? Function(CreateItem value)? createItem,
  }) {
    return getItems?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(GetItems value)? getItems,
    TResult Function(DeleteItems value)? deleteItems,
    TResult Function(CreateItem value)? createItem,
    required TResult orElse(),
  }) {
    if (getItems != null) {
      return getItems(this);
    }
    return orElse();
  }
}

abstract class GetItems implements ItemsPageEvent {
  const factory GetItems() = _$GetItems;
}

/// @nodoc
abstract class _$$DeleteItemsCopyWith<$Res> {
  factory _$$DeleteItemsCopyWith(
          _$DeleteItems value, $Res Function(_$DeleteItems) then) =
      __$$DeleteItemsCopyWithImpl<$Res>;
  @useResult
  $Res call({List<GetShopProductsEntitiesResponse> items});
}

/// @nodoc
class __$$DeleteItemsCopyWithImpl<$Res>
    extends _$ItemsPageEventCopyWithImpl<$Res, _$DeleteItems>
    implements _$$DeleteItemsCopyWith<$Res> {
  __$$DeleteItemsCopyWithImpl(
      _$DeleteItems _value, $Res Function(_$DeleteItems) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? items = null,
  }) {
    return _then(_$DeleteItems(
      null == items
          ? _value._items
          : items // ignore: cast_nullable_to_non_nullable
              as List<GetShopProductsEntitiesResponse>,
    ));
  }
}

/// @nodoc

class _$DeleteItems implements DeleteItems {
  const _$DeleteItems(final List<GetShopProductsEntitiesResponse> items)
      : _items = items;

  final List<GetShopProductsEntitiesResponse> _items;
  @override
  List<GetShopProductsEntitiesResponse> get items {
    if (_items is EqualUnmodifiableListView) return _items;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_items);
  }

  @override
  String toString() {
    return 'ItemsPageEvent.deleteItems(items: $items)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$DeleteItems &&
            const DeepCollectionEquality().equals(other._items, _items));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(_items));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$DeleteItemsCopyWith<_$DeleteItems> get copyWith =>
      __$$DeleteItemsCopyWithImpl<_$DeleteItems>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() getItems,
    required TResult Function(List<GetShopProductsEntitiesResponse> items)
        deleteItems,
    required TResult Function(
            List<XFile> pictures, String description, String name, double cost)
        createItem,
  }) {
    return deleteItems(items);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? getItems,
    TResult? Function(List<GetShopProductsEntitiesResponse> items)? deleteItems,
    TResult? Function(
            List<XFile> pictures, String description, String name, double cost)?
        createItem,
  }) {
    return deleteItems?.call(items);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? getItems,
    TResult Function(List<GetShopProductsEntitiesResponse> items)? deleteItems,
    TResult Function(
            List<XFile> pictures, String description, String name, double cost)?
        createItem,
    required TResult orElse(),
  }) {
    if (deleteItems != null) {
      return deleteItems(items);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(GetItems value) getItems,
    required TResult Function(DeleteItems value) deleteItems,
    required TResult Function(CreateItem value) createItem,
  }) {
    return deleteItems(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(GetItems value)? getItems,
    TResult? Function(DeleteItems value)? deleteItems,
    TResult? Function(CreateItem value)? createItem,
  }) {
    return deleteItems?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(GetItems value)? getItems,
    TResult Function(DeleteItems value)? deleteItems,
    TResult Function(CreateItem value)? createItem,
    required TResult orElse(),
  }) {
    if (deleteItems != null) {
      return deleteItems(this);
    }
    return orElse();
  }
}

abstract class DeleteItems implements ItemsPageEvent {
  const factory DeleteItems(final List<GetShopProductsEntitiesResponse> items) =
      _$DeleteItems;

  List<GetShopProductsEntitiesResponse> get items;
  @JsonKey(ignore: true)
  _$$DeleteItemsCopyWith<_$DeleteItems> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class _$$CreateItemCopyWith<$Res> {
  factory _$$CreateItemCopyWith(
          _$CreateItem value, $Res Function(_$CreateItem) then) =
      __$$CreateItemCopyWithImpl<$Res>;
  @useResult
  $Res call(
      {List<XFile> pictures, String description, String name, double cost});
}

/// @nodoc
class __$$CreateItemCopyWithImpl<$Res>
    extends _$ItemsPageEventCopyWithImpl<$Res, _$CreateItem>
    implements _$$CreateItemCopyWith<$Res> {
  __$$CreateItemCopyWithImpl(
      _$CreateItem _value, $Res Function(_$CreateItem) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? pictures = null,
    Object? description = null,
    Object? name = null,
    Object? cost = null,
  }) {
    return _then(_$CreateItem(
      pictures: null == pictures
          ? _value._pictures
          : pictures // ignore: cast_nullable_to_non_nullable
              as List<XFile>,
      description: null == description
          ? _value.description
          : description // ignore: cast_nullable_to_non_nullable
              as String,
      name: null == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      cost: null == cost
          ? _value.cost
          : cost // ignore: cast_nullable_to_non_nullable
              as double,
    ));
  }
}

/// @nodoc

class _$CreateItem implements CreateItem {
  const _$CreateItem(
      {required final List<XFile> pictures,
      required this.description,
      required this.name,
      required this.cost})
      : _pictures = pictures;

  final List<XFile> _pictures;
  @override
  List<XFile> get pictures {
    if (_pictures is EqualUnmodifiableListView) return _pictures;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_pictures);
  }

  @override
  final String description;
  @override
  final String name;
  @override
  final double cost;

  @override
  String toString() {
    return 'ItemsPageEvent.createItem(pictures: $pictures, description: $description, name: $name, cost: $cost)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$CreateItem &&
            const DeepCollectionEquality().equals(other._pictures, _pictures) &&
            (identical(other.description, description) ||
                other.description == description) &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.cost, cost) || other.cost == cost));
  }

  @override
  int get hashCode => Object.hash(runtimeType,
      const DeepCollectionEquality().hash(_pictures), description, name, cost);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$CreateItemCopyWith<_$CreateItem> get copyWith =>
      __$$CreateItemCopyWithImpl<_$CreateItem>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() getItems,
    required TResult Function(List<GetShopProductsEntitiesResponse> items)
        deleteItems,
    required TResult Function(
            List<XFile> pictures, String description, String name, double cost)
        createItem,
  }) {
    return createItem(pictures, description, name, cost);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? getItems,
    TResult? Function(List<GetShopProductsEntitiesResponse> items)? deleteItems,
    TResult? Function(
            List<XFile> pictures, String description, String name, double cost)?
        createItem,
  }) {
    return createItem?.call(pictures, description, name, cost);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? getItems,
    TResult Function(List<GetShopProductsEntitiesResponse> items)? deleteItems,
    TResult Function(
            List<XFile> pictures, String description, String name, double cost)?
        createItem,
    required TResult orElse(),
  }) {
    if (createItem != null) {
      return createItem(pictures, description, name, cost);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(GetItems value) getItems,
    required TResult Function(DeleteItems value) deleteItems,
    required TResult Function(CreateItem value) createItem,
  }) {
    return createItem(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(GetItems value)? getItems,
    TResult? Function(DeleteItems value)? deleteItems,
    TResult? Function(CreateItem value)? createItem,
  }) {
    return createItem?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(GetItems value)? getItems,
    TResult Function(DeleteItems value)? deleteItems,
    TResult Function(CreateItem value)? createItem,
    required TResult orElse(),
  }) {
    if (createItem != null) {
      return createItem(this);
    }
    return orElse();
  }
}

abstract class CreateItem implements ItemsPageEvent {
  const factory CreateItem(
      {required final List<XFile> pictures,
      required final String description,
      required final String name,
      required final double cost}) = _$CreateItem;

  List<XFile> get pictures;
  String get description;
  String get name;
  double get cost;
  @JsonKey(ignore: true)
  _$$CreateItemCopyWith<_$CreateItem> get copyWith =>
      throw _privateConstructorUsedError;
}
