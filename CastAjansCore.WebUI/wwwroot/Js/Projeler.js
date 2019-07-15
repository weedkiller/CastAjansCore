//var _tblProjeKarakterOyuncu = "tblProjeKarakterOyuncu_0";


function NewProjeKarakterleri() {
    var str = "";
    str += "<div class='col-md-12'>";
    str += "    <div class='card'>";
    str += "        <div class='card-header header-elements-inline'>";
    str += "            <h5 class='card-title'>Proje Karakterleri</h5>";
    str += "            <div class='header-elements'>";
    str += "                <div class='list-icons'>";
    str += "                    <a class='list-icons-item' href='javascript:ShowOyuncu(" + _projeKarakterIndex + ");'><i class='icon-plus3'></i></a>";
    str += "                </div>";
    str += "            </div>";
    str += "        </div>";
    str += "        <div class='card-body'>";
    str += "            <fieldset>";
    str += "                <input type='hidden' id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "__ProjeId' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].ProjeId' Value='0' />";
    str += "                <div class='form-group row'>";
    str += "                      <label class='col-lg-3 control-label'>Karakter Adı</label>";
    //str +=                 "      <span asp-validation-for='@Model.ProjeKarakterleri[i].Adi' class='text-danger'></span>"
    str += "                      <div class='col-lg-9'>";
    str += "                          <input id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "__Adi' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].Adi' class='form-control' />";
    str += "                      </div>";
    str += "                </div>";
    str += "                <div class='form-group row'>";
    str += "                      <label class='col-lg-3 control-label'>Karakter Sayısı</label>";
    //str +=                 "      <span asp-validation-for='@Model.ProjeKarakterleri[i].KarakterSayisi' class='text-danger'></span>";
    str += "                      <div class='col-lg-9'>";
    str += "                          <input id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "__KarakterSayisi' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].KarakterSayisi' class='form-control' />";
    str += "                      </div>";
    str += "                </div>";
    str += "                <div class='form-group row'>";
    str += "                      <label class='col-lg-3 control-label'>Açıklama</label>";
    //str +=                 "      <span asp-validation-for='@Model.ProjeKarakterleri[i].Aciklama' class='text-danger'></span>";
    str += "                      <div class='col-lg-9'>";
    str += "                          <input id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "__Aciklama' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].Aciklama' class='form-control' />";
    str += "                      </div>";
    str += "                </div>";
    str += "                <div>";
    str += "                    <table class='table' id='tblProjeKarakterOyuncu_" + _projeKarakterIndex + "'>";
    str += "                        <tbody>";
    str += "                            <tr>";
    str += "                                <th></th>";
    str += "                                <th>Ad</th>";
    str += "                                <th>Soyad</th>";
    str += "                                <th></th>";
    str += "                            </tr> ";
    str += "                        </tbody>";
    str += "                    </table>";
    str += "                </div>";
    str += "            </fieldset>";
    str += "        </div>";
    str += "    </div>";
    str += "</div>";

    $("#divProjeKarakterleri").append(str);
    _projeKarakterIndex += 1;
}

function ShowOyuncu(projeKarakterIndex) {
    _projeKarakterIndex = projeKarakterIndex;
    $('#myModal').modal('show');

}

function OyuncuEkle(profilFotoUrl, adi, soyadi, oyuncuId) {

    var table = document.getElementById("tblProjeKarakterOyuncu_" + _projeKarakterIndex);
    var rowCount = table.getElementsByTagName("tr").length - 1;

    var row = table.insertRow(rowCount + 1);
    row.id = "Proje_ProjeKarakterleri_" + _projeKarakterIndex + "__ProjeKarakterOyunculari_" + rowCount + "__tr";
    var cell0 = row.insertCell(0);
    var cell1 = row.insertCell(1);
    var cell2 = row.insertCell(2);
    var cell3 = row.insertCell(3);
    var cell4 = row.insertCell(4);
    var str = "";
    str = "<select class='form-control' data-val='true' id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "__ProjeKarakterOyunculari_" + rowCount + "__KarakterDurumu' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].ProjeKarakterOyunculari[" + rowCount + "].KarakterDurumu'>";
    str += "    <option selected = 'selected' value = '1'> Teklif Atıldı</option> ";
    str += "    <option value='2'>Kabul Edildi</option>";
    str += "    <option value='3'>Oynadı</option>";
    str += "</select>";

    if (profilFotoUrl !== "") {
        cell0.innerHTML = "<img style='width: 100px' src='" + profilFotoUrl + "' />";
    }
    cell1.innerHTML = adi;

    cell2.innerHTML = soyadi;
    cell3.innerHTML = str;
    cell4.classList.add("text-right");
    cell4.innerHTML = "<button class='btn btn-danger legitRipple' type='button' onclick='ProjeKarakterOyunculariSil(" + _projeKarakterIndex + ", " + rowCount + ");'>Sil</button>";
    cell4.innerHTML += "<input type='hidden' id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "__ProjeKarakterOyunculari_" + rowCount + "__OyuncuId' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].ProjeKarakterOyunculari[" + rowCount + "].OyuncuId'  value='" + oyuncuId + "'/>";
    cell4.innerHTML += "<input type='hidden' id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "__ProjeKarakterOyunculari_" + rowCount + "__Id' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].ProjeKarakterOyunculari[" + rowCount + "].Id'  value='0'/>";
    cell4.innerHTML += "<input type='hidden' id='Proje_ProjeKarakterleri_" + _projeKarakterIndex + "__ProjeKarakterOyunculari_" + rowCount + "__Aktif' name='Proje.ProjeKarakterleri[" + _projeKarakterIndex + "].ProjeKarakterOyunculari[" + rowCount + "].Aktif'  value='True'/>";


    //<tr id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__tr">
    //  <td>
    //        <img width="50px" src="/Resimler/OyuncuResimleri/2019/7/1966 - Okay Özdengelen (2).JPG">
    //  </td>
    //        <td>OKAY</td>
    //        <td>ÖZDENGELEN</td>
    //  <td>
    //      <select class="form-control" data-val="true" data-val-required="The KarakterDurumu field is required." id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__KarakterDurumu" name="Proje.ProjeKarakterleri[0].ProjeKarakterOyunculari[0].KarakterDurumu"><option selected="selected" value="1">Teklif Atıldı</option>
    //          <option value="2">Kabul Edildi</option>
    //          <option value="3">Oynadı</option>
    //      </select>
    //  </td >
    //  <td class="text-right">
    //      <button class="btn btn-danger legitRipple" type="button" onclick="ProjeKarakterOyunculariSil(0, 0);">Sil</button>
    //      <input type="hidden" data-val="true" data-val-required="The ProjeKarakterId field is required." id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__ProjeKarakterId" name="Proje.ProjeKarakterleri[0].ProjeKarakterOyunculari[0].ProjeKarakterId" value="1">
    //      <input type="hidden" data-val="true" data-val-required="The OyuncuId field is required." id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__OyuncuId" name="Proje.ProjeKarakterleri[0].ProjeKarakterOyunculari[0].OyuncuId" value="1000">
    //      <input type="hidden" data-val="true" data-val-required="The Id field is required." id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__Id" name="Proje.ProjeKarakterleri[0].ProjeKarakterOyunculari[0].Id" value="1">
    //      <input type="hidden" id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__EkleyenId" name="Proje.ProjeKarakterleri[0].ProjeKarakterOyunculari[0].EkleyenId" value="1">
    //      <input type="hidden" data-val="true" data-val-required="The EklemeZamani field is required." id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__EklemeZamani" name="Proje.ProjeKarakterleri[0].ProjeKarakterOyunculari[0].EklemeZamani" value="3.07.2019 23:02:50">
    //      <input type="hidden" id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__GuncelleyenId" name="Proje.ProjeKarakterleri[0].ProjeKarakterOyunculari[0].GuncelleyenId" value="1">
    //      <input type="hidden" data-val="true" data-val-required="The GuncellemeZamani field is required." id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__GuncellemeZamani" name="Proje.ProjeKarakterleri[0].ProjeKarakterOyunculari[0].GuncellemeZamani" value="4.07.2019 00:56:19">
    //      <input type="hidden" data-val="true" data-val-required="The Aktif field is required." id="Proje_ProjeKarakterleri_0__ProjeKarakterOyunculari_0__Aktif" name="Proje.ProjeKarakterleri[0].ProjeKarakterOyunculari[0].Aktif" value="True">
    //  </td>
    //</tr>

    //table.append(str);
}

function ProjeKarakterOyunculariSil(projeKarakterIndex, rowCount) {
    var id = $("#Proje_ProjeKarakterleri_" + projeKarakterIndex + "__ProjeKarakterOyunculari_" + rowCount + "__Id").val();

    if (id === "0") {
        $("#Proje_ProjeKarakterleri_" + projeKarakterIndex + "__ProjeKarakterOyunculari_" + rowCount + "__tr").remove();
    }
    else {
        $("#Proje_ProjeKarakterleri_" + projeKarakterIndex + "__ProjeKarakterOyunculari_" + rowCount + "__Aktif").val("False");
        $("#Proje_ProjeKarakterleri_" + projeKarakterIndex + "__ProjeKarakterOyunculari_" + rowCount + "__tr").hide();
    }

}
//class OyuncuFilterDto {
//    Adi = ''
//    Soyadi = ''
//    YasMin = 0
//    YasMax = 0
//}




