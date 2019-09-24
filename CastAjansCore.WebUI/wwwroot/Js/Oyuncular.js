var _tableOyuncu;
var _projeKarakterIndex = -1;


$(document).ready(function () {


    _tableOyuncu = $('#OyuncuGrid').DataTable({
        processing: true,
        responsive: false,
        searching: false,
        lengthChange: false,
        serverSide: true,
        scrollX: true,
        language: { url: "//cdn.datatables.net/plug-ins/1.10.19/i18n/Turkish.json" },
        ajax:
        {
            url: "/Oyuncular/GetOyuncuGrid",
            //contentType: "json",
            dataSrc: "data",
            //type: "Post",
            data: function (data) {
                //var json = jQuery.parseJSON(data)

                var filter = {
                    //function(d) {
                    //    var a = $.extend({}, d,
                    //        OyuncuFilterDto = {
                    TC: $("#Filter-Oyuncu-Tc").val(),
                    Adi: $("#Filter-Oyuncu-Adi").val(),
                    Soyadi: $("#Filter-Oyuncu-Soyadi").val(),
                    YasMin: Number($("#Filter-Oyuncu-YasMin").val()),
                    YasMaks: Number($("#Filter-Oyuncu-YasMaks").val()),
                    Cinsiyet: Number($("#Filter-Oyuncu-Cinsiyet").val()),
                    Uyruk: Number($("#Filter-Oyuncu-Uyruk").val()),
                    Il: Number($("#Filter-Oyuncu-Il").val()),
                    Ilce: Number($("#Filter-Oyuncu-Ilce").val()),
                    CastTipi: Number($("#Filter-Oyuncu-CastTipi").val()),
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
                    SacRengi: Number($("#Filter-Oyuncu-SacRengi").val()),
                    Ehliyet: $("#Filter-Oyuncu-Ehliyet").val(),
                    draw: data.draw,
                    order: data.order,
                    start: data.start,
                    length: data.length
                };
                return filter;
            }
        },
        columns: [
            {
                data: "id",
                searchable: false,
                bSortable: false,
                sClass: "text-center",
                width: "25px",
                render: function (data, type, row) {
                    var link = "";
                    if (_projeKarakterIndex >= 0) {
                        var disable = "";
                        if (ProjeyeEkliMi(data)) {
                            disable = "disabled";
                        }

                        link = "<a href='javascript:OyuncuEkle(\"btnOyuncuEkle_" + data + "\",\"" + row.profilFotoUrl + "\",\"" + row.adi + "\",\"" + row.soyadi + "\"," + data + ")' class='btn btn-sm btn-primary " + disable + "' id='btnOyuncuEkle_" + data + "' > <i class='mi-add'></i></a > ";

                    }
                    else {
                        link = "<a href='Oyuncular/Edit/" + data + "' class='btn btn-sm btn-primary'><i class='mi-mode-edit'></i></a>";
                    }

                    return link;
                }
            },
            {
                data: "profilFotoUrl",
                searchable: false,
                bSortable: false,
                autoWidth: false,
                width: 100,
                //visible: _isIhaleDetay == "True" ? true : false,
                sClass: "text-center",
                render: function (data, type, row) {
                    var link = "";
                    if (data === null || data === '') {
                        link = "<img src='/Resimler/yok.png' class='rounded-circle' style='max-width:100px;' />";
                    }
                    else {
                        link = "<img src='" + data + "' style='max-width:100px;' />";
                    }
                    return link;
                }
            },
            {
                name: "adsoyad",
                title: "Ad Soyad",
                data: "id",
                bSortable: false,
                autoWidth: true,
                render: function (data, type, row) {
                    var str = "";
                    str += "<div class='row media-title font-weight-semibold'><div class='col nopadding'>" + row["adi"] + " " + row["soyadi"] + "</div> <div class='col nopadding'><span class='badge badge-danger'>" + moment(row["guncellemeTarihi"]).format('DD MM YYYY') + "</span></div></div>";

                    str += "    <div class='text-nowrap'>";
                    str += "        <div class='row'><label class='col nopadding'><b>Cinsiyet</b></label><div class='col nopadding'>: " + row["cinsiyet"] + "</div></div>";
                    str += "        <div class='row'><label class='col nopadding'><b>Uyruk</b></label><div class='col nopadding'>: " + row["uyruk"] + "</div></div>";
                    str += "        <div class='row'><label class='col nopadding'><b>Saç</b></label><div class='col nopadding'>: " + row["sacRengi"] + "</div></div>";
                    str += "        <div class='row'><label class='col nopadding'><b>Ten</b></label><div class='col nopadding'>: " + row["tenRengi"] + "</div></div>";
                    str += "        <div class='row'><label class='col nopadding'><b>Göz</b></label><div class='col nopadding'>: " + row["gozRengi"] + "</div></div>";
                    str += "</div'>";

                    return str;
                }
            },
            {
                name: "Ozellik",
                title: "Özellik",
                data: "id",
                bSortable: false,
                autoWidth: true,
                render: function (data, type, row) {
                    var str = "";

                    str += "<br />";
                    str += "    <div class='text-nowrap'>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Yaş</b></label><div class='col-sm-6 nopadding text-right'>: " + row["yas"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Boy</b></label><div class='col-sm-6 nopadding text-right'>: " + row["boy"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Kilo</b></label><div class='col-sm-6 nopadding text-right'>: " + row["kilo"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Alt B.</b></label><div class='col-sm-6 nopadding text-right'>: " + row["altBeden"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Üst B.</b></label><div class='col-sm-6 nopadding text-right'>: " + row["ustBeden"] + "</div></div>";
                    str += "    </div>";

                    return str;
                }
            },
            {
                name: "projeler",
                title: "Projeler",
                data: "id",
                bSortable: false,
                autoWidth: true,
                render: function (data, type, row) {
                    var str = "";
                    for (var i = 0; i < row["projeler"].length; i++) {
                        var link = "/projeler/edit/" + row["projeler"][i].id;
                        str += "<a href='" + link+"'><span class='badge badge-primary'>" + moment(row["projeler"][i].tarihBas).format('DD MMM') + '-' + moment(row["projeler"][i].tarihBit).format('DD MMM') + "</span></a>";
                    }

                    return str;
                }
            },
            { title: "Kaşe", data: "kase" },
            {
                data: "id",
                searchable: false,
                bSortable: false,
                visible: _projeKarakterIndex < 0,
                sClass: "text-center",
                render: function (data, type, row) {
                    if (_admin) {
                        var link = "<a href='Oyuncular/Delete/" + data + "' class='btn btn-sm btn-danger'><i class='mi-delete'></i></a>";
                        return link;
                    }
                    else {
                        return "";
                    }

                }
            }
        ],
        options: {
            emptyTable: "Hiç bir kayıt yok"
        }
    });

    oTable = $('#OyuncuGrid').DataTable();


    $("#btnSearch").click(function () {

        oTable.draw();
    });
});

function ProjeyeEkliMi(oyuncuId) {
    var result = false;
    var inputs = $(".OyuncuProje");

    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].value == oyuncuId) {
            result = true;
            break;
        }
    }

    return result;
}

function ToDateStr(data) {
    if (data !== null) {
        //var dtStart = new Date(parseInt(data.substr(6)));
        var dtStartWrapper = moment(data);
        return dtStartWrapper.format('DD/MM/YYYY');
    }
    else {
        return "";
    }
}

