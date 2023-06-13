// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'get_product_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$GetProductReq _$$GetProductReqFromJson(Map<String, dynamic> json) =>
    _$GetProductReq(
      pageNumber: json['pageNumber'] as int?,
      pageSize: json['pageSize'] as int?,
      orderBy: json['orderBy'] as String?,
      isAscending: json['isAscending'] as bool?,
    );

Map<String, dynamic> _$$GetProductReqToJson(_$GetProductReq instance) =>
    <String, dynamic>{
      'pageNumber': instance.pageNumber,
      'pageSize': instance.pageSize,
      'orderBy': instance.orderBy,
      'isAscending': instance.isAscending,
    };
