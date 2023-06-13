import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/helpers/money_formatter.dart';
import 'package:flutter_dynamic_store/views/modals/web/web_modal_container.dart';
import 'package:flutter_dynamic_store/widgets/custom_input.dart';

class AddNewItemModal extends StatefulWidget {
  const AddNewItemModal({Key? key}) : super(key: key);

  @override
  State<AddNewItemModal> createState() => _AddNewItemModalState();
}

class _AddNewItemModalState extends State<AddNewItemModal> {
  final nameController = TextEditingController();
  final descriptionController = TextEditingController();
  final priceController = TextEditingController();

  @override
  void dispose() {
    nameController.dispose();
    descriptionController.dispose();
    priceController.dispose();
    super.dispose();
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
              formatters: [MoneyTextFormatter()],
            ),
            const SizedBox(height: 10),
          ],
        ),
      ),
    );
  }
}
