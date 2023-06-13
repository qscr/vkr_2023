import 'package:flutter/material.dart';
import 'package:page_transition/page_transition.dart';

enum WebRoute {
  addItemsView,
  generatorView,
}

class WebNavigatorHelper {
  static WebRoute currentRoute = WebRoute.addItemsView;

  static Future<void> pushWithReplacement<T extends Object?, TO extends Object?>({
    required BuildContext context,
    required Widget Function(BuildContext) builder,
    required WebRoute newWebRoute,
  }) async {
    currentRoute = newWebRoute;
    await Navigator.pushReplacement(
      context,
      PageTransition(
        child: builder(context),
        type: PageTransitionType.fade,
      ),
    );
  }
}
