enum MethodType {
  get("get"),
  post("post"),
  put("put"),
  delete("delete");

  const MethodType(this.value);

  final String value;

  static Map<String, MethodType> _valueMap = {};

  static MethodType fromString(String methodType) {
    if (_valueMap.isEmpty) {
      for (var value in values) {
        _valueMap[value.value] = value;
      }
    }

    return _valueMap[methodType] ?? MethodType.get;
  }
}

enum DataProviderParams {
  queryParams("queryParams"),
  methodType("methodType"),
  path("path"),
  body("body");

  const DataProviderParams(this.value);

  final String value;
}
