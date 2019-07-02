
var _tableOyuncu;
//var _gridIni = false;
function GetOyuncuGrid() {
    //alert($("#Filter-Oyuncu-Adi").val());
    //if (_gridIni == false) {
    //    _gridIni = true;
    if (_tableOyuncu != null) {
        _tableOyuncu.destroy();
    }
    var filter = {
        //function(d) {
        //    var a = $.extend({}, d,
        //        OyuncuFilterDto = {
        Adi: $("#Filter-Oyuncu-Adi").val(),
        Soyadi: $("#Filter-Oyuncu-Soyadi").val(),
        YasMin: Number($("#Filter-Oyuncu-YasMin").val()),
        YasMax: Number($("#Filter-Oyuncu-YasMaks").val()),
        Cinsiyet: Number($("#Filter-Oyuncu-Cinsiyet").val()),
        Uyruk: Number($("#Filter-Oyuncu-Uyruk").val()),
        KaseMin: Number($("#Filter-Oyuncu-KaseMin").val()),
        KaseMaks: Number($("#Filter-Oyuncu-KaseMaks").val()),
        BoyMin: Number($("#Filter-Oyuncu-BoyMin").val()),
        BoyMaks: Number($("#Filter-Oyuncu-BoyMaks").val()),
        KiloMin: Number($("#Filter-Oyuncu-KiloMin").val()),
        KiloMaks: Number($("#Filter-Oyuncu-KiloMaks").val()),
        AltBedenMin: Number($("#Filter-Oyuncu-AltBedenMin").val()),
        AltBedenMaks: Number($("#Filter-Oyuncu-AltBedenMaks").val()),
        UstBedenMin: Number($("#Filter-Oyuncu-UstBedenMin").val()),
        UstBedenMaks: Number($("#Filter-Oyuncu-UstBedenMaks").val()),
        AyakNumarasiMin: Number($("#Filter-Oyuncu-AyakNumarasiMin").val()),
        AyakNumarasiMaks: Number($("#Filter-Oyuncu-AyakNumarasiMaks").val()),
        GozRengi: Number($("#Filter-Oyuncu-GozRengi").val()),
        TenRengi: Number($("#Filter-Oyuncu-TenRengi").val()),
        SacRengi: Number($("#Filter-Oyuncu-SacRengi").val())
        //    });
        //return a;
        //}

    };
    _tableOyuncu = $('#OyuncuGrid').DataTable({
        processing: true,
        responsive: true,
        scrollX: true,
        language: { url: "//cdn.datatables.net/plug-ins/1.10.19/i18n/Turkish.json" },
        serverSide: false,
        ajax:
        {
            url: "/Oyuncular/GetOyuncuGrid",
            //contentType: "json",
            dataSrc: "",
            //type: "GET",
            data: filter

        },
        columns: [
            { data: "profilFotoUrl" },
            { title: "Adı", data: "adi" },
            { title: "Soyadı", data: "soyadi" },
            { title: "Yaş", data: "yas" },
            { title: "Uyruk", data: "uyruk" },
            { title: "Cinsiyet", data: "cinsiyet" },
            { title: "Boy", data: "boy" },
            { title: "Kilo", data: "kilo" },
            { title: "Alt Beden", data: "altBeden" },
            { title: "Üst Beden", data: "ustBeden" },
            { title: "Saç Rengi", data: "sacRengi" },
            { title: "Ten Rengi", data: "tenRengi" },
            { title: "Göz Rengi", data: "gozRengi" },
            { title: "Kaşe", data: "kase" },
            {
                data: "id",
                searchable: false,
                bSortable: false,
                //visible: _isIhaleDetay == "True" ? true : false,
                sClass: "text-center",
                render: function (data, type, row) {
                    var link = "<a href='Oyuncular/Edit/" + data + "' class='btn btn-sm btn-primary'><i class='mi-mode-edit'></i></a> |"
                    link += "<a href='Oyuncular/Delete/" + data + "' class='btn btn-sm btn-danger'><i class='mi-delete'></i></a>"
                    return link;
                }
            }
        ],
        options: {
            emptyTable: "Hiç bir kayıt yok"
        }
    });
    //}
    //    else {
    //    _table.draw();
    //}



}