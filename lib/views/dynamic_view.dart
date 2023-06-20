import 'dart:convert';

import 'package:dynamic_widget/dynamic_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/helpers/dependency_injection.dart';
import 'package:flutter_dynamic_store/helpers/provider_data_extractor.dart';
import 'package:flutter_dynamic_store/models/api/dynamic_content_response.dart';
import 'package:flutter_dynamic_store/service/api/layout_api_client.dart';

class DynamicView extends StatelessWidget {
  const DynamicView(this.dynamicContent, {Key? key}) : super(key: key);

  final DynamicContentResponse dynamicContent;

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: _buildWidget(
        context,
        dynamicContent.routes
            .firstWhere(
              (route) => route.name == dynamicContent.initialRouteName,
            )
            .contentString,
      ),
    );
  }

  Widget _buildWidget(BuildContext context, String content) {
    return DynamicWidgetBuilder.build(content, context, DefaultClickListener(dynamicContent)) ??
        Container();
  }
}

class DefaultClickListener implements ClickListener {
  final DynamicContentResponse dynamicContent;

  DefaultClickListener(this.dynamicContent);

  @override
  void onClicked(String? event, BuildContext? context) async {
    if (event != null && context != null) {
      event = extractData(event, context);
    }
    if (event?.startsWith('shop://') ?? false) {
      final id = event!.split('shop://').last;
      final apiClient = Resolver.resolve<LayoutApiClient>();
      final layout = await apiClient.getShopLayout(id);
      Navigator.of(context!).push(
        MaterialPageRoute(
          builder: (context) => Scaffold(
              body:
                  DynamicView(DynamicContentResponse.fromJson(jsonDecode(layout["layoutDesign"])))),
        ),
      );
      return;
    }
    if (event?.startsWith('route://') ?? false) {
      final nextRoute = event!.split('route://').last;
      if (context == null) {
        return;
      }
      final widget = DynamicWidgetBuilder.build(
              dynamicContent.routes.firstWhere((route) => route.name == nextRoute).contentString,
              context,
              DefaultClickListener(dynamicContent)) ??
          Container();

      Navigator.of(context).push(
        MaterialPageRoute(
          builder: (context) => widget,
        ),
      );
      return;
    }
  }
}
