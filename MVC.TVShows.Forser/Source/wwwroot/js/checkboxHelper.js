var $checkboxHelper = $checkboxHelper || {};
$checkboxHelper = function () {
    var setupCheckboxesClickEvents = function (checkboxes) {
        for (let index = 0; index < checkboxes.length; index++) {
            checkboxes[index].onClick = function () {
                if (checkboxes[index].getAttribute('aria-checked') === 'true') {
                    checkboxes[index].setAttribute('aria-checked', 'false');
                } else {
                    checkboxes[index].setAttribute('aria-checked', 'true');
                }
            };
        }
    }

    var setCheckboxesAriaChecked = function (checkboxes) {
        for (let index = 0; index < checkboxes.length; index++) {
            checkboxes[index].onClick = function () {
                checkboxes[index].setAttribute('aria-checked', 'false');
            };
        }
    }

    return {
        initialize: setupCheckboxesClickEvents,
        setAriaCheckedFalse: setCheckboxesAriaChecked
    };
}();