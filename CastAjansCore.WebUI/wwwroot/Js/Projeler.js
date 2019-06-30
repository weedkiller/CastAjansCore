var _tblProjeKarakterOyuncu = "tblProjeKarakterOyuncu_0";
var _gridIni = false;
var _table;
function NewProjeKarakterleri() {
    var str = "";
    str += "<div class='col-md-12'>";
    str += "    <div class='card'>";
    str += "        <div class='card-body'>";
    str += "            <fieldset>";
    str += "                <input type='hidden' id='Proje_ProjeKarakterleri_" + _projeKarakterleriCount + "__ProjeId' name='Proje.ProjeKarakterleri[" + _projeKarakterleriCount + "].ProjeId' Value='0' />";
    str += "                <div class='form-group row'>";
    str += "                      <label class='col-lg-3 control-label'>Karakter Adı</label>";
    //str +=                 "      <span asp-validation-for='@Model.ProjeKarakterleri[i].Adi' class='text-danger'></span>"
    str += "                      <div class='col-lg-9'>";
    str += "                          <input id='Proje_ProjeKarakterleri_" + _projeKarakterleriCount + "__Adi' name='Proje.ProjeKarakterleri[" + _projeKarakterleriCount + "].Adi' class='form-control' />";
    str += "                      </div>";
    str += "                </div>";
    str += "                <div class='form-group row'>";
    str += "                      <label class='col-lg-3 control-label'>Karakter Sayısı</label>";
    //str +=                 "      <span asp-validation-for='@Model.ProjeKarakterleri[i].KarakterSayisi' class='text-danger'></span>";
    str += "                      <div class='col-lg-9'>";
    str += "                          <input id='Proje_ProjeKarakterleri_" + _projeKarakterleriCount + "__KarakterSayisi' name='Proje.ProjeKarakterleri[" + _projeKarakterleriCount + "].KarakterSayisi' class='form-control' />";
    str += "                      </div>";
    str += "                </div>";
    str += "                <div class='form-group row'>";
    str += "                      <label class='col-lg-3 control-label'>Açıklama</label>";
    //str +=                 "      <span asp-validation-for='@Model.ProjeKarakterleri[i].Aciklama' class='text-danger'></span>";
    str += "                      <div class='col-lg-9'>";
    str += "                          <input id='Proje_ProjeKarakterleri_" + _projeKarakterleriCount + "__Aciklama' name='Proje.ProjeKarakterleri[" + _projeKarakterleriCount + "].Aciklama' class='form-control' />";
    str += "                      </div>";
    str += "                </div>";
    str += "            </fieldset>";
    str += "        </div>";
    str += "    </div>";
    str += "</div>";

    $("#divProjeKarakterleri").append(str);
    _projeKarakterleriCount += 1;
}

function ShowOyuncu(tableName) {
    _tblProjeKarakterOyuncu = tableName;
    $('#myModal').modal('show');

}

class OyuncuFilterDto {
    Adi = ''
    Soyadi = ''
    YasMin = 0
    YasMax = 0
}

function GetOyuncuGrid() {
    //alert($("#Filter-Oyuncu-Adi").val());
    //if (_gridIni == false) {
    //    _gridIni = true;
    if (_table != null) {
        _table.destroy();
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
        YasMin: Number($("#Filter-Oyuncu-YasMin").val()),
        YasMax: Number($("#Filter-Oyuncu-YasMaks").val()),
        //    });
        //return a;
        //}

    };
    _table = $('#OyuncuGrid').DataTable({
        processing: true,
        serverSide: false,
        ajax:
        {
            url: "/Oyuncular/GetOyuncuGrid",
            //contentType: "json",
            dataSrc: "oyuncular",
            //type: "GET",
            data: filter

        },
        columns: [
            { data: "profilFotoUrl" },
            { title: "Adı", data: "adi" },
            { title: "Soyadı", data: "soyadi" },
            { title:"Yaş", data: "yas" },
            { title: "Boy",data: "boy" },
            { title: "Kilo",data: "kilo" },
            { title: "Alt Beden",data: "altBeden" },
            { title: "Üst Beden",data: "ustBeden" }
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



