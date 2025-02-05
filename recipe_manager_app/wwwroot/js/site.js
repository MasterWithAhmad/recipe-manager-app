// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Title: SweetAlert for Deletion Confirmation
// Author: Ahmed Ibrahim Ahmed
// Date: 2025-02-02
// Description: Handles deletion confirmation using SweetAlert.

document.addEventListener('DOMContentLoaded', function () {
    const deleteButtons = document.querySelectorAll('.delete-recipe');

    deleteButtons.forEach(button => {
        button.addEventListener('click', function () {
            const recipeId = this.getAttribute('data-id');

            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#3085d6',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    fetch(`/Recipes/Delete/${recipeId}`, {
                        method: 'POST',
                        headers: {
                            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                        }
                    }).then(response => {
                        if (response.ok) {
                            Swal.fire(
                                'Deleted!',
                                'The recipe has been deleted.',
                                'success'
                            ).then(() => {
                                window.location.reload();
                            });
                        } else {
                            Swal.fire(
                                'Error!',
                                'Something went wrong.',
                                'error'
                            );
                        }
                    });
                }
            });
        });
    });
});
