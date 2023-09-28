var focus; 
function getFocusedButtonSeatNumber() {
    var focusedButton = document.activeElement;

    if (focusedButton && focusedButton.tagName === 'BUTTON') {
        var buttonValue = focusedButton.value;
        focus = buttonValue;
    }
}
function sendForm() {
    if (!Number.isNaN(parseInt(focus.toString()))) {
        var seatID = focus;
        var planeID = document.getElementById('center-button').dataset.planeId;
        var flightID = document.getElementById('center-button').dataset.flightId;
        var url = '/Booking/CreateBooking?seatID=' + seatID + '&planeID=' + planeID + '&flightID=' + flightID;
        window.location.href = url;
    }
} 


