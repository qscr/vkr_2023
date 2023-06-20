// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'post_file_response.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

PostFileResponse _$PostFileResponseFromJson(Map<String, dynamic> json) {
  return PostFileResp.fromJson(json);
}

/// @nodoc
mixin _$PostFileResponse {
  /// Словарь {название файла=ид сохраненного файла}
  @JsonKey(
      name: "fileNameToFileId",
      toJson: PostFileFilenameToFileIdResponse.toJson,
      fromJson: PostFileFilenameToFileIdResponse.fromJson)
  PostFileFilenameToFileIdResponse? get fileNameToFileId =>
      throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $PostFileResponseCopyWith<PostFileResponse> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $PostFileResponseCopyWith<$Res> {
  factory $PostFileResponseCopyWith(
          PostFileResponse value, $Res Function(PostFileResponse) then) =
      _$PostFileResponseCopyWithImpl<$Res, PostFileResponse>;
  @useResult
  $Res call(
      {@JsonKey(name: "fileNameToFileId", toJson: PostFileFilenameToFileIdResponse.toJson, fromJson: PostFileFilenameToFileIdResponse.fromJson)
          PostFileFilenameToFileIdResponse? fileNameToFileId});

  $PostFileFilenameToFileIdResponseCopyWith<$Res>? get fileNameToFileId;
}

/// @nodoc
class _$PostFileResponseCopyWithImpl<$Res, $Val extends PostFileResponse>
    implements $PostFileResponseCopyWith<$Res> {
  _$PostFileResponseCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? fileNameToFileId = freezed,
  }) {
    return _then(_value.copyWith(
      fileNameToFileId: freezed == fileNameToFileId
          ? _value.fileNameToFileId
          : fileNameToFileId // ignore: cast_nullable_to_non_nullable
              as PostFileFilenameToFileIdResponse?,
    ) as $Val);
  }

  @override
  @pragma('vm:prefer-inline')
  $PostFileFilenameToFileIdResponseCopyWith<$Res>? get fileNameToFileId {
    if (_value.fileNameToFileId == null) {
      return null;
    }

    return $PostFileFilenameToFileIdResponseCopyWith<$Res>(
        _value.fileNameToFileId!, (value) {
      return _then(_value.copyWith(fileNameToFileId: value) as $Val);
    });
  }
}

/// @nodoc
abstract class _$$PostFileRespCopyWith<$Res>
    implements $PostFileResponseCopyWith<$Res> {
  factory _$$PostFileRespCopyWith(
          _$PostFileResp value, $Res Function(_$PostFileResp) then) =
      __$$PostFileRespCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {@JsonKey(name: "fileNameToFileId", toJson: PostFileFilenameToFileIdResponse.toJson, fromJson: PostFileFilenameToFileIdResponse.fromJson)
          PostFileFilenameToFileIdResponse? fileNameToFileId});

  @override
  $PostFileFilenameToFileIdResponseCopyWith<$Res>? get fileNameToFileId;
}

/// @nodoc
class __$$PostFileRespCopyWithImpl<$Res>
    extends _$PostFileResponseCopyWithImpl<$Res, _$PostFileResp>
    implements _$$PostFileRespCopyWith<$Res> {
  __$$PostFileRespCopyWithImpl(
      _$PostFileResp _value, $Res Function(_$PostFileResp) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? fileNameToFileId = freezed,
  }) {
    return _then(_$PostFileResp(
      freezed == fileNameToFileId
          ? _value.fileNameToFileId
          : fileNameToFileId // ignore: cast_nullable_to_non_nullable
              as PostFileFilenameToFileIdResponse?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$PostFileResp implements PostFileResp {
  const _$PostFileResp(
      @JsonKey(name: "fileNameToFileId", toJson: PostFileFilenameToFileIdResponse.toJson, fromJson: PostFileFilenameToFileIdResponse.fromJson)
          this.fileNameToFileId);

  factory _$PostFileResp.fromJson(Map<String, dynamic> json) =>
      _$$PostFileRespFromJson(json);

  /// Словарь {название файла=ид сохраненного файла}
  @override
  @JsonKey(
      name: "fileNameToFileId",
      toJson: PostFileFilenameToFileIdResponse.toJson,
      fromJson: PostFileFilenameToFileIdResponse.fromJson)
  final PostFileFilenameToFileIdResponse? fileNameToFileId;

  @override
  String toString() {
    return 'PostFileResponse(fileNameToFileId: $fileNameToFileId)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$PostFileResp &&
            (identical(other.fileNameToFileId, fileNameToFileId) ||
                other.fileNameToFileId == fileNameToFileId));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, fileNameToFileId);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$PostFileRespCopyWith<_$PostFileResp> get copyWith =>
      __$$PostFileRespCopyWithImpl<_$PostFileResp>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$PostFileRespToJson(
      this,
    );
  }
}

abstract class PostFileResp implements PostFileResponse {
  const factory PostFileResp(
      @JsonKey(name: "fileNameToFileId", toJson: PostFileFilenameToFileIdResponse.toJson, fromJson: PostFileFilenameToFileIdResponse.fromJson)
          final PostFileFilenameToFileIdResponse?
              fileNameToFileId) = _$PostFileResp;

  factory PostFileResp.fromJson(Map<String, dynamic> json) =
      _$PostFileResp.fromJson;

  @override

  /// Словарь {название файла=ид сохраненного файла}
  @JsonKey(
      name: "fileNameToFileId",
      toJson: PostFileFilenameToFileIdResponse.toJson,
      fromJson: PostFileFilenameToFileIdResponse.fromJson)
  PostFileFilenameToFileIdResponse? get fileNameToFileId;
  @override
  @JsonKey(ignore: true)
  _$$PostFileRespCopyWith<_$PostFileResp> get copyWith =>
      throw _privateConstructorUsedError;
}
