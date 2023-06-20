import 'dart:convert';

import 'package:dio/dio.dart';

class LayoutApiClient {
  final Dio _dio;
  final String _baseUrl;

  const LayoutApiClient(this._dio, String baseUrl) : _baseUrl = "$baseUrl/Layout";

  Future<Map<String, dynamic>> getMainLayout() async {
    final response = await _dio.get("$_baseUrl/Main");
    return response.data;
  }

  Future<void> updateLayout(Map<String, dynamic> newLayout) async {
    await _dio.put(_baseUrl, data: {"data": jsonEncode(newLayout)});
  }

  Future<Map<String, dynamic>> getShopLayout(String id) async {
    final response = await _dio.get("$_baseUrl/Shop/$id");
    return response.data;
  }
}
