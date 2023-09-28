function searchFlight() {
    var input = document.getElementById("search-input");
    var table = document.querySelector(".table");
    var tr = table.querySelectorAll("tr");
    var filter = input.value.toUpperCase(); 

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) 
            {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}