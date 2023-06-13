import 'package:dio/dio.dart';

extension DioHelper on Dio {
  void setAuthorizationToken(String token) {
    options.headers["Authorization"] = "Bearer $token";
  }

  void deleteAuthorizationToken() {
    options.headers.remove("Authorization");
  }
}
