import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/models/enums.dart';

class DataFetcher extends ChangeNotifier {
  DataFetcher(
    this._baseUrl,
    this._dio,
    this._methodType,
    this._path,
    this._queryParams,
    this._body,
  ) {
    fetch();
  }

  final String _baseUrl;

  final Dio _dio;

  final MethodType _methodType;

  final String _path;

  final Map<String, dynamic>? _queryParams;

  final Map<String, dynamic>? _body;

  String get _url => "$_baseUrl/$_path";

  Map<String, dynamic> get data => _data;

  bool isLoading = true;

  set data(Map<String, dynamic> data) {
    _data = data;
    notifyListeners();
  }

  Map<String, dynamic> _data = {};

  bool error = false;

  Future<void> fetch() async {
    try {
      Response? response;
      switch (_methodType) {
        case MethodType.get:
          response = await _dio.get(
            _url,
            queryParameters: _queryParams,
            data: _body,
          );
          break;
        case MethodType.post:
          response = await _dio.post(
            _url,
            data: _body,
            queryParameters: _queryParams,
          );
          break;
        case MethodType.put:
          response = await _dio.put(
            _url,
            data: _body,
            queryParameters: _queryParams,
          );
          break;
        case MethodType.delete:
          response = await _dio.delete(
            _url,
            data: _body,
            queryParameters: _queryParams,
          );
          break;
      }
      if (response.data is Map) {
        isLoading = false;
        data = response.data;
      }
    } catch (e) {
      error = true;
    }
  }
}
