$(document).ready(function () {
    // Form submit
    $('#filterForm').on('submit', function () {
        $('#loadingSpinner').removeClass('d-none');
        $('.btn-primary').prop('disabled', true);
    });

    // Reset button
    $('.btn-outline-secondary').on('click', function (e) {
        e.preventDefault();
        $('#filterForm')[0].reset();
        window.location.href = '/Home/Index';
    });

    // Table row hover
    $('.product-row').hover(
        function () { $(this).addClass('table-light'); },
        function () { $(this).removeClass('table-light'); }
    );

    // Filter toggle icon
    $('#filterCollapse').on('show.bs.collapse', function () {
        $(this).prev().find('.fa-chevron-down').removeClass('fa-chevron-down').addClass('fa-chevron-up');
    }).on('hide.bs.collapse', function () {
        $(this).prev().find('.fa-chevron-up').removeClass('fa-chevron-up').addClass('fa-chevron-down');
    });
});