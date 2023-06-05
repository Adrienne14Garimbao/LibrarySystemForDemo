/*  For Books > Create or Edit   */
(function ($) {

    var _booksAppService = abp.services.app.book,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=BooksForm]');

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

        var book = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);


        if (book.Id != 0) {
            _booksAppService.update(book).done(function () {
                redirectToBookIndex();
                abp.message.success('Successfully Updated!', 'Updated');

            });
        }
        else // > Create 
        {
            _booksAppService.create(book).done(function () {
                redirectToBookIndex();
                abp.message.success('Successfully Saved!', 'Saved');
            });
        }
    }

    function redirectToBookIndex() {
        abp.notify.info('Success', 'Message');
        window.location.href = "/Book";
    }

    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = "/Book";
                }
            });

    }


})(jQuery);