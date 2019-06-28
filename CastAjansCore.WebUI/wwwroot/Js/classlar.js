class OyuncuFilterDto {
    Adi = ''
    Soyadi = ''
    YasMin = 0
    YasMax = 0
}

function GetOyuncuGrid() {
    $('#OyuncuGrid').DataTable({
        processing: true,
        //"serverSide": true,
        contentType: "application/json",
        ajax:
        {
            url: "/Oyuncular/GetOyuncuGrid",
            data: {
                Adi: $("#Filter-Oyuncu-Adi"),
                Soyadi: $("#Filter-Oyuncu-Soyadi"),
                YasMin: $("#Filter-Oyuncu-YasMin"),
                YasMax: $("#Filter-Oyuncu-YasMax")
            }
        },
        columns: [
            { data: "Adi" },
            { data: "Soyadi" }//,
            //{ "data": "contact.0" },
            //{ "data": "contact.1" },
            //{ "data": "hr.start_date" },
            //{ "data": "hr.salary" }
        ]
    });
}