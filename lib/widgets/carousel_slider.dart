import 'package:carousel_slider/carousel_slider.dart';
import 'package:flutter/material.dart';

class CarouselItem {
  final String imageUrl;

  final VoidCallback onClick;

  CarouselItem({
    required this.imageUrl,
    required this.onClick,
  });
}

class Carousel extends StatelessWidget {
  const Carousel({required this.items, Key? key}) : super(key: key);

  final List<CarouselItem> items;

  @override
  Widget build(BuildContext context) {
    return CarouselSlider(
      options: CarouselOptions(
        autoPlay: true,
        autoPlayInterval: const Duration(seconds: 10),
      ),
      items: items.map((i) {
        return Builder(
          builder: (BuildContext context) {
            return GestureDetector(
              behavior: HitTestBehavior.opaque,
              onTap: i.onClick,
              child: Padding(
                padding: const EdgeInsets.all(16),
                child: ClipRRect(
                  child: Image.network(i.imageUrl),
                ),
              ),
            );
          },
        );
      }).toList(),
    );
  }
}
