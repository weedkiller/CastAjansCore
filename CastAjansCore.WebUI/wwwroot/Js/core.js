
$(document).ready(function () {
    $('.datepicker').datepicker();

});

$.validator.methods.date = function (value, element) {
    return this.optional(element) || moment(value, "DD.MM.YYYY", true).isValid();
};

jQuery.validator.methods["date"] = function (value, element) { return true; };

$.validator.addMethod('date', function (value, element) {
    if (this.optional(element)) {
        return true;
    }
    var valid = true;
    try {
        $.datepicker.parseDate('dd.mm.yy', value);
    }
    catch (err) {
        valid = false;
    }
    return valid;
}); 

function GetIlceler(ddlIl, ddlIlce) {
    $.getJSON("/Ilceler/GetJson", { id: ddlIl.val() },
        function (data) {
            ddlIlce.empty();
            ddlIlce.append($('<option/>', {
                value: 0,
                text: "Seçiniz"
            }));
            $.each(data, function (index, itemData) {
                ddlIlce.append($('<option/>', {
                    value: itemData.id,
                    text: itemData.adi
                }));
            });
        });
} 