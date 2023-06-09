﻿// #region Jquery for Borrower > Create or Edit

(function ($) {

    var _borrowerAppService = abp.services.app.borrower,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=BorrowerForm]');

    var _borrowerPage = "/Borrower";

    // #region Cancel Button

    _$form.find('.cancel-button').on('click', (e) => {
        cancelAndReturn();
    })
    // #endregion

    // #region Get Current Date and Add 7 Days

    var BorrowDate = new Date(),
        ExpectedReturnDate = new Date();

    ExpectedReturnDate.setDate(ExpectedReturnDate.getDate(BorrowDate) + 7); 

    document.getElementById('BorrowDate').value = BorrowDate.toISOString().split("T")[0]// ISO format to split date (y/m/d)
    document.getElementById('ExpectedReturnDate').value = ExpectedReturnDate.toISOString().split("T")[0]


    // #endregion


    // #region save() - Create Borrower
    function save() {

        // #region Validation

        if (!_$form.valid()) {
            return;
        }

        // #endregion

        // #region Converts a form into an object
        var borrower = _$form.serializeFormToObject();
        // #endregion

        // #region Form sets to busy while waiting
        abp.ui.setBusy(_$form);
        // #endregion

        if (borrower.Id != 0) 
        {
            // #region Update
            _borrowerAppService.update(borrower).done(function () {
                redirectToBorrowerIndex();
                abp.message.success('Successfully Updated!', 'Updated');
            });
            //#endregion
        }
        else /* Create */
        {  
            _borrowerAppService.create(borrower).done(function () {
                //borrower.ReturnDate = null;
                redirectToBorrowerIndex();
                abp.message.success('Successfully Saved!', 'Saved');

            });
        }

    }
    // #endregion

    // #region redirectToBorrowerIndex() - Return to borrower page 
    function redirectToBorrowerIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = _borrowerPage;
    }
    // #endregion

    // #region cancelAndReturn() - Cancel and go back to borrower page
    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = _borrowerPage;
                }
            });
    }
    // #endregion

    // #region Save Button 
    _$form.find('.save-button').on('click', (e) => {
        save();
    })
    // #endregion

})(jQuery);
// #endregion
