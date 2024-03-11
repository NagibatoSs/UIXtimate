function newField() {
    // определяем контейнер для хранения полей с вопросами
    let container = document.getElementById("visualContents");
    // получаем текущее количество input (полей для вопросов)
    let fieldCount = container.getElementsByTagName("input").length;
    // увеличиваем Id для нового поля
    let nextFieldId = fieldCount + 1;

    // здесь добавляем элемент, который будет хранить input (в моем случае, у вас может быть по другому или вообще не быть его)
    let div = document.createElement("div");
    div.setAttribute("class", "form-group");

    // создаем новое поле с новым id, name ДОЛЖЕН СОВПАДАТЬ С ИМЕНЕМ ПОЛЯ В МОДЕЛИ!!!
    let field = document.createElement("input");
    field.setAttribute("class", "form-control");
    field.setAttribute("id", "VisualContents[" + nextFieldId + "]");
    field.setAttribute("name", "VisualContents");
    field.setAttribute("type", "text");
    field.setAttribute("placeholder", "Укажите ссылку на Figma проект");
    field.setAttribute("asp-for", "VisualContents[" + nextFieldId + "]")

    // добавляем поле в <div class="form-group"></div>
    div.appendChild(field);
    // добавляем <div class="form-group"><input ... /></div> в главный контейнер
    container.appendChild(div);
}
