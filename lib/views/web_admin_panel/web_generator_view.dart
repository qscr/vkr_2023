import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/models/api/dynamic_content_response.dart';
import 'package:flutter_dynamic_store/models/api/route_item_response.dart';
import 'package:flutter_dynamic_store/providers/widgets_provider.dart';
import 'package:flutter_dynamic_store/test_json_string.dart';
import 'package:flutter_dynamic_store/views/dynamic_view.dart';
import 'package:flutter_dynamic_store/widgets/web_admin_panel_widgets/custom_navigation_bar.dart';
import 'package:flutter_dynamic_store/widgets/web_admin_panel_widgets/semantic_item.dart';
import 'package:flutter_dynamic_store/widgets/web_admin_panel_widgets/semantic_item_options.dart';
import 'package:provider/provider.dart';

enum DirectionToMove {
  up,
  down,
}

final Map<String, BaseSemanticItemOptions> optionsByNameMap = {
  "DynamicText": TextSemanticOptions(),
  "DynamicPicture": PictureSemanticOptions(),
  "SizedBox": SizedBoxOptions(),
};

class WebGeneratorView extends StatefulWidget {
  const WebGeneratorView({Key? key}) : super(key: key);

  @override
  State<WebGeneratorView> createState() => _WebGeneratorViewState();
}

class _WebGeneratorViewState extends State<WebGeneratorView> {
  final List<Map<String, dynamic>> layout = [];
  final dynamicContent = DynamicContentResponse.fromJson(jsonDecode(testJsonRouteString));
  Color backgroundColor = Colors.black;

  void moveElements({
    required Map<String, dynamic> elementToMove,
    required Map<String, dynamic> elementToPlace,
    required DirectionToMove direction,
  }) {
    if (layout.length < 2) {
      return;
    }
    layout.removeWhere((element) => element["id"] == elementToMove["id"]);
    int indexToMove = layout.indexOf(elementToPlace);
    if (direction == DirectionToMove.down) {
      indexToMove++;
    }

    layout.insert(indexToMove, elementToMove);
    setState(() {});
  }

  void update() {
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(
          create: (context) => WidgetsProvider({}),
        ),
      ],
      child: Scaffold(
        appBar: CustomAppBar(context),
        body: Row(
          children: [
            Expanded(
              child: Container(
                color: Colors.grey,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Expanded(
                      child: Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: GridView.count(
                          crossAxisCount: 4,
                          children: [
                            SemanticItem(
                              name: "Текст",
                              json: Map<String, dynamic>.from({
                                "type": "DynamicText",
                                "data": "",
                              }),
                              moveFunc: moveElements,
                            ),
                            SemanticItem(
                              name: "Картинка",
                              json: Map<String, dynamic>.from({
                                "type": "DynamicPicture",
                                "url": "",
                              }),
                              moveFunc: moveElements,
                            ),
                            SemanticItem(
                              name: "SizedBox",
                              json: Map<String, dynamic>.from({
                                "type": "SizedBox",
                              }),
                              moveFunc: moveElements,
                            ),
                            SemanticItem(
                              name: "Категория",
                              json: Map<String, dynamic>.from({
                                "type": "category",
                              }),
                              moveFunc: moveElements,
                            ),
                            SemanticItem(
                              name: "Карусель",
                              json: Map<String, dynamic>.from({"type": "carousel"}),
                              moveFunc: moveElements,
                            ),
                          ],
                        ),
                      ),
                    ),
                    DragTarget<Map<String, dynamic>>(
                      builder: (context, candidate, rejected) => Container(
                        height: 200,
                        width: 200,
                        color: candidate.isNotEmpty ? Colors.blue : Colors.red,
                        child: const Text("Мусорка"),
                      ),
                      onAccept: (data) {
                        if (data.containsKey("id")) {
                          final id = data["id"];
                          layout.removeWhere((element) => element["id"] == id);
                          setState(() {});
                        }
                      },
                    ),
                  ],
                ),
              ),
            ),
            Expanded(
              child: Container(
                color: Colors.green,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    DragTarget<Map<String, dynamic>>(
                      builder: (context, candidate, rejected) => Container(
                        width: 350,
                        height: 600,
                        color: candidate.isNotEmpty ? Colors.red : backgroundColor,
                        child: layout.isNotEmpty
                            ? Column(
                                children: layout.map((item) {
                                  return SemanticItem(
                                    name: item["name"],
                                    json: item,
                                    moveFunc: moveElements,
                                    isTemplate: false,
                                    options: optionsByNameMap[item["type"]],
                                    updateFunc: update,
                                  );
                                }).toList(),
                              )
                            : const SizedBox(),
                      ),
                      onAccept: (data) {
                        final id = data["id"];
                        if (layout.any((element) => element["id"] == id)) {
                          return;
                        }
                        layout.add({...data});
                      },
                    )
                  ],
                ),
              ),
            ),
            Expanded(
              child: Container(
                color: Colors.blue,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Container(
                      color: Theme.of(context).scaffoldBackgroundColor,
                      height: 600,
                      width: 350,
                      child: Builder(
                        builder: (context) {
                          final dynamicContent = DynamicContentResponse(
                            initialRouteName: "Test",
                            routes: [
                              RouteItemResponse(name: "Test", content: {
                                "type": "Column",
                                "children": layout,
                              }),
                            ],
                            widgets: [],
                          );
                          // context.read<WidgetsProvider>().widgets = dynamicContent.widgetsMap;
                          return DynamicView(dynamicContent);
                        },
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
