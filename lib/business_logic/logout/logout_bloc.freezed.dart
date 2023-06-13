// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'logout_bloc.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
mixin _$LogoutState {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() logoutInitial,
    required TResult Function() logoutLoading,
    required TResult Function() logoutSuccess,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? logoutInitial,
    TResult? Function()? logoutLoading,
    TResult? Function()? logoutSuccess,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? logoutInitial,
    TResult Function()? logoutLoading,
    TResult Function()? logoutSuccess,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LogoutInitial value) logoutInitial,
    required TResult Function(LogoutLoading value) logoutLoading,
    required TResult Function(LogoutSuccess value) logoutSuccess,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(LogoutInitial value)? logoutInitial,
    TResult? Function(LogoutLoading value)? logoutLoading,
    TResult? Function(LogoutSuccess value)? logoutSuccess,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LogoutInitial value)? logoutInitial,
    TResult Function(LogoutLoading value)? logoutLoading,
    TResult Function(LogoutSuccess value)? logoutSuccess,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $LogoutStateCopyWith<$Res> {
  factory $LogoutStateCopyWith(
          LogoutState value, $Res Function(LogoutState) then) =
      _$LogoutStateCopyWithImpl<$Res, LogoutState>;
}

/// @nodoc
class _$LogoutStateCopyWithImpl<$Res, $Val extends LogoutState>
    implements $LogoutStateCopyWith<$Res> {
  _$LogoutStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;
}

/// @nodoc
abstract class _$$LogoutInitialCopyWith<$Res> {
  factory _$$LogoutInitialCopyWith(
          _$LogoutInitial value, $Res Function(_$LogoutInitial) then) =
      __$$LogoutInitialCopyWithImpl<$Res>;
}

/// @nodoc
class __$$LogoutInitialCopyWithImpl<$Res>
    extends _$LogoutStateCopyWithImpl<$Res, _$LogoutInitial>
    implements _$$LogoutInitialCopyWith<$Res> {
  __$$LogoutInitialCopyWithImpl(
      _$LogoutInitial _value, $Res Function(_$LogoutInitial) _then)
      : super(_value, _then);
}

/// @nodoc

class _$LogoutInitial with DiagnosticableTreeMixin implements LogoutInitial {
  const _$LogoutInitial();

  @override
  String toString({DiagnosticLevel minLevel = DiagnosticLevel.info}) {
    return 'LogoutState.logoutInitial()';
  }

  @override
  void debugFillProperties(DiagnosticPropertiesBuilder properties) {
    super.debugFillProperties(properties);
    properties.add(DiagnosticsProperty('type', 'LogoutState.logoutInitial'));
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is _$LogoutInitial);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() logoutInitial,
    required TResult Function() logoutLoading,
    required TResult Function() logoutSuccess,
  }) {
    return logoutInitial();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? logoutInitial,
    TResult? Function()? logoutLoading,
    TResult? Function()? logoutSuccess,
  }) {
    return logoutInitial?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? logoutInitial,
    TResult Function()? logoutLoading,
    TResult Function()? logoutSuccess,
    required TResult orElse(),
  }) {
    if (logoutInitial != null) {
      return logoutInitial();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LogoutInitial value) logoutInitial,
    required TResult Function(LogoutLoading value) logoutLoading,
    required TResult Function(LogoutSuccess value) logoutSuccess,
  }) {
    return logoutInitial(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(LogoutInitial value)? logoutInitial,
    TResult? Function(LogoutLoading value)? logoutLoading,
    TResult? Function(LogoutSuccess value)? logoutSuccess,
  }) {
    return logoutInitial?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LogoutInitial value)? logoutInitial,
    TResult Function(LogoutLoading value)? logoutLoading,
    TResult Function(LogoutSuccess value)? logoutSuccess,
    required TResult orElse(),
  }) {
    if (logoutInitial != null) {
      return logoutInitial(this);
    }
    return orElse();
  }
}

abstract class LogoutInitial implements LogoutState {
  const factory LogoutInitial() = _$LogoutInitial;
}

/// @nodoc
abstract class _$$LogoutLoadingCopyWith<$Res> {
  factory _$$LogoutLoadingCopyWith(
          _$LogoutLoading value, $Res Function(_$LogoutLoading) then) =
      __$$LogoutLoadingCopyWithImpl<$Res>;
}

/// @nodoc
class __$$LogoutLoadingCopyWithImpl<$Res>
    extends _$LogoutStateCopyWithImpl<$Res, _$LogoutLoading>
    implements _$$LogoutLoadingCopyWith<$Res> {
  __$$LogoutLoadingCopyWithImpl(
      _$LogoutLoading _value, $Res Function(_$LogoutLoading) _then)
      : super(_value, _then);
}

/// @nodoc

class _$LogoutLoading with DiagnosticableTreeMixin implements LogoutLoading {
  const _$LogoutLoading();

  @override
  String toString({DiagnosticLevel minLevel = DiagnosticLevel.info}) {
    return 'LogoutState.logoutLoading()';
  }

  @override
  void debugFillProperties(DiagnosticPropertiesBuilder properties) {
    super.debugFillProperties(properties);
    properties.add(DiagnosticsProperty('type', 'LogoutState.logoutLoading'));
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is _$LogoutLoading);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() logoutInitial,
    required TResult Function() logoutLoading,
    required TResult Function() logoutSuccess,
  }) {
    return logoutLoading();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? logoutInitial,
    TResult? Function()? logoutLoading,
    TResult? Function()? logoutSuccess,
  }) {
    return logoutLoading?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? logoutInitial,
    TResult Function()? logoutLoading,
    TResult Function()? logoutSuccess,
    required TResult orElse(),
  }) {
    if (logoutLoading != null) {
      return logoutLoading();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LogoutInitial value) logoutInitial,
    required TResult Function(LogoutLoading value) logoutLoading,
    required TResult Function(LogoutSuccess value) logoutSuccess,
  }) {
    return logoutLoading(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(LogoutInitial value)? logoutInitial,
    TResult? Function(LogoutLoading value)? logoutLoading,
    TResult? Function(LogoutSuccess value)? logoutSuccess,
  }) {
    return logoutLoading?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LogoutInitial value)? logoutInitial,
    TResult Function(LogoutLoading value)? logoutLoading,
    TResult Function(LogoutSuccess value)? logoutSuccess,
    required TResult orElse(),
  }) {
    if (logoutLoading != null) {
      return logoutLoading(this);
    }
    return orElse();
  }
}

abstract class LogoutLoading implements LogoutState {
  const factory LogoutLoading() = _$LogoutLoading;
}

/// @nodoc
abstract class _$$LogoutSuccessCopyWith<$Res> {
  factory _$$LogoutSuccessCopyWith(
          _$LogoutSuccess value, $Res Function(_$LogoutSuccess) then) =
      __$$LogoutSuccessCopyWithImpl<$Res>;
}

/// @nodoc
class __$$LogoutSuccessCopyWithImpl<$Res>
    extends _$LogoutStateCopyWithImpl<$Res, _$LogoutSuccess>
    implements _$$LogoutSuccessCopyWith<$Res> {
  __$$LogoutSuccessCopyWithImpl(
      _$LogoutSuccess _value, $Res Function(_$LogoutSuccess) _then)
      : super(_value, _then);
}

/// @nodoc

class _$LogoutSuccess with DiagnosticableTreeMixin implements LogoutSuccess {
  const _$LogoutSuccess();

  @override
  String toString({DiagnosticLevel minLevel = DiagnosticLevel.info}) {
    return 'LogoutState.logoutSuccess()';
  }

  @override
  void debugFillProperties(DiagnosticPropertiesBuilder properties) {
    super.debugFillProperties(properties);
    properties.add(DiagnosticsProperty('type', 'LogoutState.logoutSuccess'));
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is _$LogoutSuccess);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() logoutInitial,
    required TResult Function() logoutLoading,
    required TResult Function() logoutSuccess,
  }) {
    return logoutSuccess();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? logoutInitial,
    TResult? Function()? logoutLoading,
    TResult? Function()? logoutSuccess,
  }) {
    return logoutSuccess?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? logoutInitial,
    TResult Function()? logoutLoading,
    TResult Function()? logoutSuccess,
    required TResult orElse(),
  }) {
    if (logoutSuccess != null) {
      return logoutSuccess();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LogoutInitial value) logoutInitial,
    required TResult Function(LogoutLoading value) logoutLoading,
    required TResult Function(LogoutSuccess value) logoutSuccess,
  }) {
    return logoutSuccess(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(LogoutInitial value)? logoutInitial,
    TResult? Function(LogoutLoading value)? logoutLoading,
    TResult? Function(LogoutSuccess value)? logoutSuccess,
  }) {
    return logoutSuccess?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LogoutInitial value)? logoutInitial,
    TResult Function(LogoutLoading value)? logoutLoading,
    TResult Function(LogoutSuccess value)? logoutSuccess,
    required TResult orElse(),
  }) {
    if (logoutSuccess != null) {
      return logoutSuccess(this);
    }
    return orElse();
  }
}

abstract class LogoutSuccess implements LogoutState {
  const factory LogoutSuccess() = _$LogoutSuccess;
}

/// @nodoc
mixin _$LogoutEvent {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() logout,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? logout,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? logout,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(Logout value) logout,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(Logout value)? logout,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(Logout value)? logout,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $LogoutEventCopyWith<$Res> {
  factory $LogoutEventCopyWith(
          LogoutEvent value, $Res Function(LogoutEvent) then) =
      _$LogoutEventCopyWithImpl<$Res, LogoutEvent>;
}

/// @nodoc
class _$LogoutEventCopyWithImpl<$Res, $Val extends LogoutEvent>
    implements $LogoutEventCopyWith<$Res> {
  _$LogoutEventCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;
}

/// @nodoc
abstract class _$$LogoutCopyWith<$Res> {
  factory _$$LogoutCopyWith(_$Logout value, $Res Function(_$Logout) then) =
      __$$LogoutCopyWithImpl<$Res>;
}

/// @nodoc
class __$$LogoutCopyWithImpl<$Res>
    extends _$LogoutEventCopyWithImpl<$Res, _$Logout>
    implements _$$LogoutCopyWith<$Res> {
  __$$LogoutCopyWithImpl(_$Logout _value, $Res Function(_$Logout) _then)
      : super(_value, _then);
}

/// @nodoc

class _$Logout with DiagnosticableTreeMixin implements Logout {
  const _$Logout();

  @override
  String toString({DiagnosticLevel minLevel = DiagnosticLevel.info}) {
    return 'LogoutEvent.logout()';
  }

  @override
  void debugFillProperties(DiagnosticPropertiesBuilder properties) {
    super.debugFillProperties(properties);
    properties.add(DiagnosticsProperty('type', 'LogoutEvent.logout'));
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is _$Logout);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() logout,
  }) {
    return logout();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? logout,
  }) {
    return logout?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? logout,
    required TResult orElse(),
  }) {
    if (logout != null) {
      return logout();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(Logout value) logout,
  }) {
    return logout(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(Logout value)? logout,
  }) {
    return logout?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(Logout value)? logout,
    required TResult orElse(),
  }) {
    if (logout != null) {
      return logout(this);
    }
    return orElse();
  }
}

abstract class Logout implements LogoutEvent {
  const factory Logout() = _$Logout;
}
