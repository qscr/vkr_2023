import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/business_logic/items_page/items_page_bloc.dart';
import 'package:flutter_dynamic_store/helpers/image_helper.dart';

import 'package:flutter_dynamic_store/views/modals/web/web_modal_container.dart';
import 'package:flutter_dynamic_store/widgets/carousel_slider.dart';
import 'package:flutter_dynamic_store/widgets/custom_input.dart';
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';

class AddNewItemModal extends StatefulWidget {
  const AddNewItemModal({Key? key}) : super(key: key);

  @override
  State<AddNewItemModal> createState() => _AddNewItemModalState();
}

class _AddNewItemModalState extends State<AddNewItemModal> {
  final nameController = TextEditingController();
  final descriptionController = TextEditingController();
  final priceController = TextEditingController();
  final imagePicker = ImagePicker();
  final List<XFile> pickedFiles = [];

  @override
  void initState() {
    nameController.addListener(() {
      setState(() {});
    });
    descriptionController.addListener(() {
      setState(() {});
    });
    priceController.addListener(() {
      setState(() {});
    });
    super.initState();
  }

  @override
  void dispose() {
    nameController.dispose();
    descriptionController.dispose();
    priceController.dispose();
    super.dispose();
  }

  bool isInputValid() {
    final allFieldsContainsText = nameController.text.isNotEmpty &&
        descriptionController.text.isNotEmpty &&
        priceController.text.isNotEmpty;
    final priceIsDouble = double.tryParse(priceController.text) != null;
    return allFieldsContainsText && priceIsDouble;
  }

  @override
  Widget build(BuildContext context) {
    return WebModalContainer(
      child: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          children: [
            CustomInput(
              controller: nameController,
              hintText: "Название",
            ),
            const SizedBox(height: 10),
            CustomInput(
              controller: descriptionController,
              hintText: "Описание",
            ),
            const SizedBox(height: 10),
            CustomInput(
              controller: priceController,
              hintText: "Цена за штуку",
              // formatters: [MoneyTextFormatter()],
            ),
            const SizedBox(height: 10),
            pickedFiles.isNotEmpty
                ? Column(
                    children: [
                      Carousel(
                        items: pickedFiles
                            .map((e) => CarouselItem(imageUrl: e.path, onClick: () {}))
                            .toList(),
                      ),
                      const SizedBox(height: 10),
                    ],
                  )
                : const SizedBox(),
            ElevatedButton.icon(
              onPressed: () async {
                final pickedFile = await imagePicker.pickImage(
                  source: ImageSource.camera,
                );
                if (pickedFile == null) {
                  return;
                }
                if (!pickedFile.isValidImage()) {
                  return;
                }
                setState(() {
                  pickedFiles.add(pickedFile);
                });
              },
              icon: const Icon(Icons.add_a_photo),
              label: const Text("Добавить картинку"),
            ),
            const SizedBox(height: 10),
            ElevatedButton.icon(
              onPressed: isInputValid()
                  ? () {
                      context.read<ItemsPageBloc>().add(
                            CreateItem(
                              pictures: pickedFiles,
                              description: descriptionController.text,
                              name: nameController.text,
                              cost: double.tryParse(priceController.text) != null
                                  ? double.tryParse(priceController.text)!
                                  : 0,
                            ),
                          );
                      Navigator.of(context).pop();
                    }
                  : null,
              icon: const Icon(Icons.check_circle),
              label: const Text("Готово"),
            ),
          ],
        ),
      ),
    );
  }
}
