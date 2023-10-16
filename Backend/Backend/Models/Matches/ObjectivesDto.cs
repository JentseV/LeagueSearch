namespace Backend.Models.Matches
{
    public class ObjectivesDto
    {
        public ObjectivesDto(ObjectiveDto baron, ObjectiveDto champion, ObjectiveDto dragon,
            ObjectiveDto inhibitor, ObjectiveDto riftHerald, ObjectiveDto tower)
        {
            Baron = baron;
            Champion = champion;
            Dragon = dragon;
            Inhibitor = inhibitor;
            RiftHerald = riftHerald;
            Tower = tower;
        }

        public ObjectiveDto Baron { get; set; }
        public ObjectiveDto Champion { get; set; }
        public ObjectiveDto Dragon { get; set; }
        public ObjectiveDto Inhibitor { get; set; }
        public ObjectiveDto RiftHerald { get; set; }
        public ObjectiveDto Tower { get; set; }
    }
}
