/*  For Borrower > Index   */
(function ($) {

    var _borrowerAppService = abp.services.app.borrower,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=borrowerSearchForm]');

    /*  Search  */
    _$form.find('.btn-search').on('click', (e) => {
        window.location.href = "/Borrower/Index";

    });


    $(document).on('click', '.edit-book', function () {
        var borrowerId = $(this).attr("data-borrower-id");
        window.location.href = "/Borrower/CreateOrEdit/" + borrowerId;

    });


    $(document).on('click', '.delete-borrower', function () {
        var borrowerId = $(this).attr("data-borrower-id");
        var borrowerName = $(this).attr("data-borrower-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), borrowerName), '',

            function (isConfirmed) {
                if (isConfirmed) {
                    _borrowerAppService.delete({ id: bookId }).done(function () {
                        window.location.href = "/Borrower"
                        abp.notify.info(l('SuccessfullyDeleted'), 'Message');
                    })
                }
            }

        );

})(jQuery);

