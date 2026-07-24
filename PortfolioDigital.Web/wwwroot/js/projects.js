/**
 * Affiche le modal pour les détails du projet via l'index
 * @param {number} index - Index du projet dans le tableau
 */
let projectModalInstance;

function getModalInstance(modalElement) {
    const bootstrapApi = window.bootstrap;
    if (!modalElement || !bootstrapApi || !bootstrapApi.Modal) {
        return null;
    }

    if (typeof bootstrapApi.Modal.getOrCreateInstance === 'function') {
        return bootstrapApi.Modal.getOrCreateInstance(modalElement, {
            backdrop: false,
            keyboard: true,
            focus: true
        });
    }

    return bootstrapApi.Modal.getInstance(modalElement)
        || new bootstrapApi.Modal(modalElement, {
            backdrop: false,
            keyboard: true,
            focus: true
        });
}

function cleanupStaleModalArtifacts(force = false) {
    // If a previous modal lifecycle broke, these leftovers can block the page.
    const hasOpenModal = document.querySelector('.modal.show');
    if (hasOpenModal && !force) {
        return;
    }

    document.body.classList.remove('modal-open');
    document.body.style.removeProperty('overflow');
    document.body.style.removeProperty('padding-right');

    document.querySelectorAll('.modal-backdrop').forEach((backdrop) => {
        backdrop.remove();
    });
}

function unlockBodyScrollForProjectModal() {
    document.body.classList.add('modal-unlocked-scroll');
    document.body.classList.remove('modal-open');
    document.body.style.removeProperty('overflow');
    document.body.style.removeProperty('padding-right');
}


function showProjectModalByIndex(index) {
    if (typeof projects === 'undefined' || !projects[index]) {
        console.error('Projet non trouvé à l\'index:', index);
        return;
    }

    const project = projects[index];
    const modalElement = document.getElementById('projectModal');

    if (!modalElement) {
        console.error('Modal introuvable: #projectModal');
        return;
    }

    const titleEl = document.getElementById('projectTitle');
    const descriptionEl = document.getElementById('projectDescription');
    const positionEl = document.getElementById('projectPosition');
    const dateEl = document.getElementById('projectDate');
    const companyEl = document.getElementById('projectCompany');
    const locationEl = document.getElementById('projectLocation');
    const list = document.getElementById('projectTechnologiesList');

    if (!titleEl || !descriptionEl || !positionEl || !dateEl || !companyEl || !locationEl || !list) {
        console.error('Elements modal manquants pour afficher les details projet');
        return;
    }

    projectModalInstance = getModalInstance(modalElement);
    if (!projectModalInstance) {
        console.error('Impossible de creer/recuperer l\'instance Bootstrap modal');
        return;
    }

    cleanupStaleModalArtifacts(true);
    
    // Remplir les infos du modal
    titleEl.textContent = project.title;
    descriptionEl.textContent = project.description;
    positionEl.textContent = project.position;
    dateEl.textContent = project.startDate + ' - ' + project.endDate;
    companyEl.textContent = project.company;
    locationEl.textContent = project.location;
    
    // Remplir la liste des technologies
    const techArray = Array.isArray(project.technologies) ? project.technologies : [];
    list.innerHTML = '';

    const fragment = document.createDocumentFragment();

    techArray.forEach(tech => {
        const techLabel = (tech || '').trim();
        if (!techLabel) {
            return;
        }

        const badge = document.createElement('span');
        badge.textContent = techLabel;
        fragment.appendChild(badge);
    });

    list.appendChild(fragment);

    modalElement.addEventListener('hidden.bs.modal', () => {
        document.body.classList.remove('modal-unlocked-scroll');
        cleanupStaleModalArtifacts(true);
    }, { once: true });

    modalElement.addEventListener('shown.bs.modal', () => {
        unlockBodyScrollForProjectModal();
    }, { once: true });

    try {
        requestAnimationFrame(() => {
            projectModalInstance.show();
            unlockBodyScrollForProjectModal();
        });
    } catch (error) {
        console.error('Erreur lors de l\'ouverture du modal:', error);
        document.body.classList.remove('modal-unlocked-scroll');
        cleanupStaleModalArtifacts(true);
    }
}
