// #region Jquery for Borrower > Index
(function ($) {

    var _borrowerAppService = abp.services.app.borrower,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=borrowerSearchForm]');

    // #region Search Borrower  
    _$form.find('.btn-search').on('click', (e) => {
        window.location.href = "/Borrower/Index";

    });
    // #endregion

    // #region Edit/Update Borrower
    $(document).on('click', '.update-borrower', function () {

        var borrowerId = $(this).attr("data-borrower-id");
        var borrowerReturnDate = $(this).attr("data-date-of-return");

        //window.location.href = "/Borrower/CreateOrEdit/" + borrowerId;

        window.location.href = "/Borrower/CreateOrEdit/" + borrowerId + borrowerReturnDate;

    });
    // #endregion

    // #region Delete  Borrower
    $(document).on('click', '.delete-borrower', function () {
        var borrowerId = $(this).attr("data-borrower-id");
        var borrowerName = $(this).attr("data-borrower-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), borrowerName), '',

            function (isConfirmed) {
                if (isConfirmed) {
                    _borrowerAppService.delete({ id: borrowerId }).done(function () {
                        window.location.href = "/Borrower"
                        abp.notify.info(l('SuccessfullyDeleted'), 'Message');
                    })
                }
            }

        );

    });
    // #endregion 


})(jQuery);
// #endregion

