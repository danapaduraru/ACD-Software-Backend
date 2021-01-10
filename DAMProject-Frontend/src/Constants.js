export const endpoints = {
    JOB_POSITIONS: "https://localhost:44395/JobPositions",
    JOB_POSITION_BY_ID: "https://localhost:44395/JobPositions/",
    APPLICATIONS_FOR_JOB_POSITION: "https://localhost:44395/Applications/jobid/",
    APPLICATIONS_FOR_APPLICANT: "https://localhost:44395/Applications/applicantid/",
    APPLICANT_BY_ID: "https://localhost:44395/Persons/",
    INTERVIEWS_FOR_PERSON_ID: "https://localhost:44395/Interviews/GetByPersonId/",
    ADD_APPLICATION: "https://localhost:44395/Applications",
    ADD_INTERVIEW: "https://localhost:44395/Interviews",
};

export default endpoints;