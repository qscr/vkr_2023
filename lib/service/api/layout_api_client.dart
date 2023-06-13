import 'package:dio/dio.dart';

class LayoutApiClient {
  final Dio _dio;
  final String _baseUrl;

  const LayoutApiClient(this._dio, String baseUrl) : _baseUrl = "$baseUrl/Layout";

  Future<Map<String, dynamic>> getMainLayout() async {
    final response = await _dio.get("$_baseUrl/Main");
    return response.data;
  }
}
