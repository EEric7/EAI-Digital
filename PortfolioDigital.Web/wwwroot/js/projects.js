/**
 * Affiche le modal pour les détails du projet via l'index
 * @param {number} index - Index du projet dans le tableau
 */
function showProjectModalByIndex(index) {
    if (typeof projects === 'undefined' || !projects[index]) {
        console.error('Projet non trouvé à l\'index:', index);
        return;
    }

    const project = projects[index];
    const modal = new bootstrap.Modal(document.getElementById('projectModal'));
    
    // Remplir les infos du modal
    document.getElementById('projectTitle').textContent = project.title;
    document.getElementById('projectDescription').textContent = project.description;
    document.getElementById('projectPosition').textContent = project.position;
    document.getElementById('projectImage').src = project.imageUrl;
    document.getElementById('projectImage').alt = project.title;
    document.getElementById('projectDate').textContent = project.startDate + ' - ' + project.endDate;
    document.getElementById('projectCompany').textContent = project.company;
    document.getElementById('projectLocation').textContent = project.location;
    
    // Remplir la liste des technologies
    const techArray = Array.isArray(project.technologies) ? project.technologies : [];
    const list = document.getElementById('projectTechnologiesList');
    list.innerHTML = '';
    
    techArray.forEach(tech => {
        const span = document.createElement('span');
        span.style.padding = '5px 5px';
        span.innerHTML = tech.trim();
        span.classList.add('glass');
        list.appendChild(span);
    });
    
    modal.show();
}
