$(document).ready(function () {
    moment.locale('tr');
});

//$.validator.methods.date = function (value, element) {
//    return this.optional(element) || moment(value, "DD.MM.YYYY", true).isValid();
//};

//jQuery.validator.methods["date"] = function (value, element) { return true; };

//$.validator.addMethod('date', function (value, element) {
//    if (this.optional(element)) {
//        return true;
//    }
//    var valid = true;
//    try {
//        $.datepicker.parseDate('dd.mm.yy', value);
//    }
//    catch (err) {
//        valid = false;
//    }
//    return valid;
//}); 


function ResimCevir(control, src) {
    $.ajax
        ({
            //url :veri istenilen php dosyasının adresi
            url: '/Oyuncular/ResimCevir/',
            type: "Post",
            data: { resimUrl: src },
            success: function (donen_veri) {
                var img = document.getElementById(control);
                if (donen_veri === "OK") {
                    img.src = src + "?t = " + new Date().getTime();
                }
                else {
                    alert(donen_veri);
                }
            }
        });
}

function GetIlceler(ddlIl, ddlIlce) {
    $.getJSON("/Ilceler/GetJson", { id: ddlIl.val() },
        function (data) {
            ddlIlce.empty();
            ddlIlce.append($('<option/>', {
                val: null,
                text: "Seçiniz"
            }));
            $.each(data, function (index, itemData) {
                ddlIlce.append($('<option/>', {
                    value: itemData.id,
                    text: itemData.adi
                }));
            });
        }
    );
}

function getSelectValues(select) {
    var result = [];
    var options = select && select.options;
    var opt;

    for (var i = 0, iLen = options.length; i < iLen; i++) {
        opt = options[i];

        if (opt.selected) {
            result.push(opt.value || opt.text);
        }
    }
    return result;
}

var Modals = function () {


    //
    // Setup module components
    //

    // Load remote content
    //var _componentModalRemote = function () {
    //    $('#modal_remote').on('show.bs.modal', function () {
    //        $(this).find('.modal-body').load('../../../../global_assets/demo_data/wizard/education.html', function () {
    //            _componentSelect2();
    //        });
    //    });
    //};

    // Modal callbacks
    var _componentModalCallbacks = function () {

        // onShow callback
        $('#modal_onshow').on('show.bs.modal', function () {
            alert('onShow callback fired.')
        });

        // onShown callback
        $('#modal_onshown').on('shown.bs.modal', function () {
            alert('onShown callback fired.')
        });

        // onHide callback
        $('#modal_onhide').on('hide.bs.modal', function () {
            alert('onHide callback fired.')
        });

        // onHidden callback
        $('#modal_onhidden').on('hidden.bs.modal', function () {
            alert('onHidden callback fired.');
        });
    };

    // Bootbox extension
    var _componentModalBootbox = function () {
        if (typeof bootbox === 'undefined') {
            console.warn('Warning - bootbox.min.js is not loaded.');
            return;
        }

        // Alert dialog
        $('#alert').on('click', function () {
            bootbox.alert({
                title: 'Check this out!',
                message: 'Native alert dialog has been replaced with Bootbox alert box.'
            });
        });

        // Confirmation dialog
        $('.silModal').on('click', function (e) {

            var $target = $(e.target);
            // modal targeted by the button
            var refId = $target.data('refid');


            bootbox.confirm({
                title: 'Kayıt Silme İşlemi',
                message: refId + ' referans numarali kaydı silmek istediğinize emin misiniz?',
                buttons: {
                    confirm: {
                        label: 'Sil',
                        className: 'btn-danger'
                    },
                    cancel: {
                        label: 'Vazgeç',
                        className: 'btn-link'
                    }
                },
                callback: function (result) {
                    if (result) {
                        $.post(
                            "/Iller/DeleteConfirmed",
                            { id: refId },
                            function (data) {
                                alert("Response: " + data);
                            }
                        );                        
                    }
                    //bootbox.alert({
                    //    title: 'Confirmation result',
                    //    message: 'Confirm result: ' + result
                    //});
                }
            });
        });
    };


    return {
        initComponents: function () {
            //_componentModalRemote();
            _componentModalCallbacks();
            _componentModalBootbox();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function () {
    Modals.initComponents();
});
