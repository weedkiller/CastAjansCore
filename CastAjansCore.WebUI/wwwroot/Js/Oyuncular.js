﻿var _tableOyuncu;
var _projeKarakterIndex = -1;


$(document).ready(function () {


    _tableOyuncu = $('#OyuncuGrid').DataTable({
        processing: true,
        //responsive: true,
        searching: false,
        lengthChange: false,
        serverSide: true,
        //scrollX: true,
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
                render: function (data, type, row) {
                    var link = "";
                    if (_projeKarakterIndex >= 0) {
                        link = "<a href='javascript:OyuncuEkle(\"" + row.profilFotoUrl + "\",\"" + row.adi + "\",\"" + row.soyadi + "\"," + data + ")' class='btn btn-sm btn-primary' > <i class='mi-add'></i></a > ";
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

                    str += "<div class='row media-title font-weight-semibold'>" + row["adi"] + " " + row["soyadi"] + "<span style='color:red;'>" + row["guncellemeTarihi"] + "</span></div>";
                    str += "<div class='row'>";
                    str += "    <div class='col-md-6'>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Cinsiyet</b></label><div class='col-sm-6 nopadding'>: " + row["cinsiyet"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Uyruk</b></label><div class='col-sm-6 nopadding'>: " + row["uyruk"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Saç</b></label><div class='col-sm-6 nopadding'>: " + row["sacRengi"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Ten</b></label><div class='col-sm-6 nopadding'>: " + row["tenRengi"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Göz</b></label><div class='col-sm-6 nopadding'>: " + row["gozRengi"] + "</div></div>";
                    str += "    </div>";
                    str += "    <div class='col-md-6'>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Yaş</b></label><div class='col-sm-6 nopadding text-right'> " + row["yas"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Boy</b></label><div class='col-sm-6 nopadding text-right'> " + row["boy"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Kilo</b></label><div class='col-sm-6 nopadding text-right'> " + row["kilo"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Alt B.</b></label><div class='col-sm-6 nopadding text-right'> " + row["altBeden"] + "</div></div>";
                    str += "        <div class='row'><label class='col-sm-6 nopadding'><b>Üst B.</b></label><div class='col-sm-6 nopadding text-right'> " + row["ustBeden"] + "</div></div>";
                    str += "    </div>";
                    str += "</div'>";

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
                    var link = "<a href='Oyuncular/Delete/" + data + "' class='btn btn-sm btn-danger'><i class='mi-delete'></i></a>";
                    return link;
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


