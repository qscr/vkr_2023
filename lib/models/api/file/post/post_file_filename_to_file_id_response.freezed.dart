// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'post_file_filename_to_file_id_response.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
mixin _$PostFileFilenameToFileIdResponse {
  String? get fileId => throw _privateConstructorUsedError;

  @JsonKey(ignore: true)
  $PostFileFilenameToFileIdResponseCopyWith<PostFileFilenameToFileIdResponse>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $PostFileFilenameToFileIdResponseCopyWith<$Res> {
  factory $PostFileFilenameToFileIdResponseCopyWith(
          PostFileFilenameToFileIdResponse value,
          $Res Function(PostFileFilenameToFileIdResponse) then) =
      _$PostFileFilenameToFileIdResponseCopyWithImpl<$Res,
          PostFileFilenameToFileIdResponse>;
  @useResult
  $Res call({String? fileId});
}

/// @nodoc
class _$PostFileFilenameToFileIdResponseCopyWithImpl<$Res,
        $Val extends PostFileFilenameToFileIdResponse>
    implements $PostFileFilenameToFileIdResponseCopyWith<$Res> {
  _$PostFileFilenameToFileIdResponseCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? fileId = freezed,
  }) {
    return _then(_value.copyWith(
      fileId: freezed == fileId
          ? _value.fileId
          : fileId // ignore: cast_nullable_to_non_nullable
              as String?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$FilenameToFileIdCopyWith<$Res>
    implements $PostFileFilenameToFileIdResponseCopyWith<$Res> {
  factory _$$FilenameToFileIdCopyWith(
          _$FilenameToFileId value, $Res Function(_$FilenameToFileId) then) =
      __$$FilenameToFileIdCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({String? fileId});
}

/// @nodoc
class __$$FilenameToFileIdCopyWithImpl<$Res>
    extends _$PostFileFilenameToFileIdResponseCopyWithImpl<$Res,
        _$FilenameToFileId> implements _$$FilenameToFileIdCopyWith<$Res> {
  __$$FilenameToFileIdCopyWithImpl(
      _$FilenameToFileId _value, $Res Function(_$FilenameToFileId) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? fileId = freezed,
  }) {
    return _then(_$FilenameToFileId(
      freezed == fileId
          ? _value.fileId
          : fileId // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }
}

/// @nodoc

class _$FilenameToFileId implements FilenameToFileId {
  const _$FilenameToFileId(this.fileId);

  @override
  final String? fileId;

  @override
  String toString() {
    return 'PostFileFilenameToFileIdResponse(fileId: $fileId)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$FilenameToFileId &&
            (identical(other.fileId, fileId) || other.fileId == fileId));
  }

  @override
  int get hashCode => Object.hash(runtimeType, fileId);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$FilenameToFileIdCopyWith<_$FilenameToFileId> get copyWith =>
      __$$FilenameToFileIdCopyWithImpl<_$FilenameToFileId>(this, _$identity);
}

abstract class FilenameToFileId implements PostFileFilenameToFileIdResponse {
  const factory FilenameToFileId(final String? fileId) = _$FilenameToFileId;

  @override
  String? get fileId;
  @override
  @JsonKey(ignore: true)
  _$$FilenameToFileIdCopyWith<_$FilenameToFileId> get copyWith =>
      throw _privateConstructorUsedError;
}
