function changeButtonCondition() {
    var checkBox = document.getElementById("check-accept");
    var button = document.getElementById("accept-button");
    button.disabled = !checkBox.checked;
}

function changeButtonConditionForRB() {
    var button = document.getElementById("next-button");
    button.disabled = false;
}