/*  For Author > Create or Edit   */
(function ($) {

    var _authorAppService = abp.services.app.author,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=AuthorForm]');

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

        var author = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (author.Id != 0) // > Update or Edit
        {
            _authorAppService.update(author).done(function () {
                redirectToAuthorIndex();
                abp.message.success('Successfully Updated!', 'Updated');
            });
        }
        else // > Then > Create 
        {
            _authorAppService.create(author).done(function () {
                redirectToAuthorIndex();
                abp.message.success('Successfully Saved!', 'Saved');
            });
        }

    }

    function redirectToAuthorIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = "/Author";
    }

    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = "/Author";
                }
            });
    }


})(jQuery);