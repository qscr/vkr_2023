import 'package:dynamic_widget/dynamic_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/helpers/image_helper.dart';
import 'package:flutter_dynamic_store/helpers/provider_data_extractor.dart';
import 'package:flutter_dynamic_store/providers/data_fetcher.dart';
import 'package:flutter_dynamic_store/widgets/carousel_slider.dart';
import 'package:provider/provider.dart';

class CarouselParser extends WidgetParser {
  @override
  Map<String, dynamic>? export(Widget? widget, BuildContext? buildContext) {
    throw UnimplementedError();
  }

  @override
  Widget parse(Map<String, dynamic> map, BuildContext buildContext, ClickListener? listener) {
    List<dynamic> items = [];
    if (map['items'] != null) {
      items = map['items'];
      return Builder(
        builder: (context) {
          return Carousel(
            items: items.map((e) {
              return CarouselItem(
                imageUrl: e['url'],
                onClick: () {
                  if (listener != null && e['event'] != null) {
                    listener.onClicked(e['event'], context);
                  }
                },
              );
            }).toList(),
          );
        },
      );
    } else {
      items = buildContext.read<DataFetcher>().data[map["key"]] as List<dynamic>;
    }

    return Builder(
      builder: (context) {
        return Carousel(
          items: items.map((e) {
            return CarouselItem(
              imageUrl: getImageUrlById(extractDataFromMap(map['url'], e)),
              onClick: () {
                if (listener != null && e['event'] != null) {
                  listener.onClicked(e['event'], context);
                }
              },
            );
          }).toList(),
        );
      },
    );
  }

  @override
  String get widgetName => "Carousel";

  @override
  Type get widgetType => Carousel;
}
