import 'package:dynamic_widget/dynamic_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/models/api/dynamic_content_response.dart';

class DynamicView extends StatelessWidget {
  const DynamicView(this.dynamicContent, {Key? key}) : super(key: key);

  final DynamicContentResponse dynamicContent;

  @override
  Widget build(BuildContext context) {
    return _buildWidget(
      context,
      dynamicContent.routes
          .firstWhere(
            (route) => route.name == dynamicContent.initialRouteName,
          )
          .contentString,
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
    }
    print("Receive click event: ${event ?? ''}");
  }
}
