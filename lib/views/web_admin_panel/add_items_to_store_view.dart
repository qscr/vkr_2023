import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/items_page/items_page_bloc.dart';
import 'package:flutter_dynamic_store/helpers/image_helper.dart';
import 'package:flutter_dynamic_store/helpers/money_formatter.dart';
import 'package:flutter_dynamic_store/models/api/product/get/get_shop_products_entities_response.dart';
import 'package:flutter_dynamic_store/views/modals/web/add_new_item_modal.dart';
import 'package:flutter_dynamic_store/widgets/carousel_slider.dart';
import 'package:flutter_dynamic_store/widgets/loading_screen.dart';
import 'package:flutter_dynamic_store/widgets/web_admin_panel_widgets/custom_checkbox.dart';
import 'package:flutter_dynamic_store/widgets/web_admin_panel_widgets/custom_navigation_bar.dart';

class AddItemsToStoreView extends StatefulWidget {
  const AddItemsToStoreView({Key? key}) : super(key: key);

  @override
  State<AddItemsToStoreView> createState() => _AddItemsToStoreViewState();
}

class _AddItemsToStoreViewState extends State<AddItemsToStoreView> {
  final List<GetShopProductsEntitiesResponse> itemsToDelete = [];
  bool deletionModeOn = false;

  @override
  void initState() {
    context.read<ItemsPageBloc>().add(const GetItems());
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: CustomAppBar(context),
      body: BlocConsumer<ItemsPageBloc, ItemsPageState>(
        listener: (context, state) {
          if (state is ItemsSuccess) {
            itemsToDelete.clear();
          }
        },
        builder: (context, state) {
          if (state is ItemsLoading || state is Initial) {
            return const LoadingScreen();
          }
          if (state is ItemsSuccess) {
            return Column(
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    ElevatedButton.icon(
                      label: const Text("Добавить новый товар"),
                      onPressed: () {
                        showDialog(
                          context: context,
                          builder: (ctx) => BlocProvider.value(
                            value: context.read<ItemsPageBloc>(),
                            child: const AddNewItemModal(),
                          ),
                        );
                      },
                      icon: const Icon(Icons.add),
                    ),
                    const SizedBox(width: 20),
                    ElevatedButton.icon(
                      label: Text(
                        deletionModeOn ? "Выйти из режима удаления" : "Режим удаления товаров",
                      ),
                      onPressed: () {
                        if (deletionModeOn) {
                          itemsToDelete.clear();
                        }
                        setState(() {
                          deletionModeOn = !deletionModeOn;
                        });
                      },
                      icon: const Icon(Icons.delete),
                      style: ElevatedButton.styleFrom(
                        foregroundColor: Colors.white,
                        backgroundColor: Colors.red,
                      ),
                    ),
                    const SizedBox(width: 20),
                    deletionModeOn
                        ? ElevatedButton.icon(
                            label: const Text(
                              "Удалить выбранные товары",
                            ),
                            onPressed: itemsToDelete.isNotEmpty
                                ? () {
                                    context.read<ItemsPageBloc>().add(DeleteItems(itemsToDelete));

                                    setState(() {
                                      deletionModeOn = !deletionModeOn;
                                    });
                                  }
                                : null,
                            icon: const Icon(Icons.delete),
                            style: ElevatedButton.styleFrom(
                              foregroundColor: Colors.white,
                              backgroundColor: Colors.red,
                            ),
                          )
                        : const SizedBox(),
                  ],
                ),
                const SizedBox(height: 20),
                Expanded(
                  child: GridView.builder(
                    itemCount: state.items.length,
                    gridDelegate:
                        const SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: 4),
                    itemBuilder: (context, index) {
                      final item = state.items[index];

                      return Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Container(
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(12),
                            color: Theme.of(context).disabledColor,
                          ),
                          child: Column(
                            children: [
                              (item.photoIds?.isNotEmpty ?? false)
                                  ? Carousel(
                                      items: item.photoIds!
                                          .map(
                                            (e) => CarouselItem(
                                              imageUrl: getImageUrlById(e),
                                              onClick: () {},
                                            ),
                                          )
                                          .toList(),
                                    )
                                  : const SizedBox(),
                              Expanded(
                                child: Padding(
                                  padding: const EdgeInsets.all(8.0),
                                  child: Row(
                                    children: [
                                      Column(
                                        crossAxisAlignment: CrossAxisAlignment.start,
                                        children: [
                                          Text("Название продукта: ${item.name ?? ''}"),
                                          Text("Описание: ${item.description ?? ''}"),
                                          Text("Цена: ${item.price?.toMoneyString() ?? ''}"),
                                          deletionModeOn
                                              ? CustomCheckbox(
                                                  value: itemsToDelete.contains(item),
                                                  onChanged: (value) {
                                                    if (value == null) {
                                                      return;
                                                    }
                                                    if (value) {
                                                      itemsToDelete.add(item);
                                                    } else {
                                                      itemsToDelete.remove(item);
                                                    }
                                                    setState(() {});
                                                  },
                                                )
                                              : const SizedBox(),
                                        ],
                                      ),
                                    ],
                                  ),
                                ),
                              ),
                            ],
                          ),
                        ),
                      );
                    },
                  ),
                ),
              ],
            );
          }
          return const Text("error");
        },
      ),
    );
  }
}
