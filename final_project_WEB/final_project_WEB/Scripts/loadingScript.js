function loading() {

    let timerInterval;
    Swal.fire({
        title: 'היי! מכינים לך את המערכת, ממש עוד רגע',
        html: 'נתחיל בעוד <b></b> <i class="ti-timer mx-0"></i>',
        timer: 3000,
        timerProgressBar: true,
        onBeforeOpen: () => {
            Swal.showLoading()
            timerInterval = setInterval(() => {
                Swal.getContent().querySelector('b')
                    .textContent = Swal.getTimerLeft()
            }, 100)
        },
        onClose: () => {
            clearInterval(timerInterval)
        }
    }).then((result) => {
        if (
            result.dismiss === Swal.DismissReason.timer
        ) { }
    })
}