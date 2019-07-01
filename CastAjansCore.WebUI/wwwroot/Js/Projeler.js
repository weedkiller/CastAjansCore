var _tblProjeKarakterOyuncu = "tblProjeKarakterOyuncu_0";


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

//class OyuncuFilterDto {
//    Adi = ''
//    Soyadi = ''
//    YasMin = 0
//    YasMax = 0
//}




