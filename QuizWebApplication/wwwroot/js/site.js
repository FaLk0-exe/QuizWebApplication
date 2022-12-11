function changeButtonCondition() {
    var checkBox = document.getElementById("check-accept");
    var button = document.getElementById("accept-button");
    button.disabled = !checkBox.checked;
}