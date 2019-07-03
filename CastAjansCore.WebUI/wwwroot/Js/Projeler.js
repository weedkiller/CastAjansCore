//var _tblProjeKarakterOyuncu = "tblProjeKarakterOyuncu_0";


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

function ShowOyuncu(projeKarakterIndex) {
    _projeKarakterIndex = projeKarakterIndex;
    $('#myModal').modal('show');

}

function OyuncuEkle(profilFotoUrl, adi, soyadi, oyuncuId) {

    var table = document.getElementById("tblProjeKarakterOyuncu_" + _projeKarakterIndex);
    var rowCount = table.getElementsByTagName("tr").length - 1;
    var row = table.insertRow(rowCount);
    var cell0 = row.insertCell(0);
    var cell1 = row.insertCell(1);
    var cell2 = row.insertCell(2);
    var cell3 = row.insertCell(3);
    var cell4 = row.insertCell(4);
    cell0.innerHTML = "<img width='50px' src='" + profilFotoUrl + "' />";
    cell1.innerHTML = adi;
    cell2.innerHTML = soyadi;
    cell3.innerHTML = "";
    cell4.innerHTML = "<input type='hidden' id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "_ProjeKarakterOyunculari_" + rowCount + "__OyuncuId' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].ProjeKarakterOyunculari[" + rowCount + "].OyuncuId'  value='" + oyuncuId + "'/>";
    cell4.innerHTML += "<input type='hidden' id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "_ProjeKarakterOyunculari_" + rowCount + "__Aktif' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].ProjeKarakterOyunculari[" + rowCount + "].Aktif'  value='True'/>";

    //var str = "";
    //str += "<tr>";
    //str += "    <td>";
    //str += "        <img width='50px' src='" + ProfilFotoUrl + "' />";
    //str += "    </td>";
    //str += "    <td>" +  + "</td>";
    //str += "    <td>" + Soyadi + "</td>";
    //str += "    <td></td>";
    //str += "    <td>";
    //str += "        <button class='btn btn-danger' onclick='ProjeKarakterOyunculariSil(" + _projeKarakterIndex + ", " + rowCount + ");'>Sil</button>";
    //str += "        <input type='hidden' id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "_ProjeKarakterOyunculari_" + rowCount + "__OyuncuId'  value='" + OyuncuId + "'/>";
    //str += "    </td>";
    //str += "</tr>";

    //table.append(str);
}

//class OyuncuFilterDto {
//    Adi = ''
//    Soyadi = ''
//    YasMin = 0
//    YasMax = 0
//}




