/*  For Borrower > Create or Edit   */

(function ($) {

    var _borrowerAppService = abp.services.app.borrower,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=BorrowerForm]');

    _$form.find('.save-button').on('click', (e) => {
        save();
    })

    _$form.find('.cancel-button').on('click', (e) => {
        cancelAndReturn();
    })

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var borrower = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (borrower.Id != 0) 
        {
            _borrowerAppService.update(borrower).done(function () {
                redirectToBorrowerIndex();
                abp.message.success('Successfully Updated!', 'Updated');
            });
        }
        else // > Create 
        {
            _borrowerAppService.create(borrower).done(function () {
                redirectToBorrowerIndex();
                abp.message.success('Successfully Saved!', 'Saved');

            });
        }

    }

    function redirectToBorrowerIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = "/Borrower";
    }

    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = "/Borrower";
                }
            });
    }


})(jQuery);
